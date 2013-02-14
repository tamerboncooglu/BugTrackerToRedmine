using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugTrackerLibrary;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.jsch.examples;

namespace BugTrackerToRedmineApp
{
    public partial class FrmTransferBugs : Form
    {
        public FrmTransferBugs()
        {
            InitializeComponent();
        }

        readonly List<BugModel> _bugsModels = new List<BugModel>();
        readonly BugTrackerEntities _bugTrackerEntities = new BugTrackerEntities();
        JSch jsch = new JSch();
        private Session session;
        private void FrmTransferBugs_Load(object sender, EventArgs e)
        {
            GetBTBugs();

            grdBTBugs.ReadOnly = false;
            for (int i = 0; i < grdBTBugs.Columns.Count; i++)
            {
                if (grdBTBugs.Columns[i] != null)
                    grdBTBugs.Columns[i].ReadOnly = true;
            }

            grdBTBugs.Columns["IsSelected"].ReadOnly = false;
        }

        private void GetBTBugs()
        {
            foreach (var bug in _bugTrackerEntities.bugs.ToList())
            {
                _bugsModels.Add(new BugModel
                {
                    AssignedUser = bug.bg_assigned_to_user,
                    BugId = bug.bg_id,
                    Category = bug.bg_category,
                    Description = bug.Nasıl_oluşturuluyor,
                    Priority = bug.bg_priority,
                    ReportedDate = bug.bg_reported_date,
                    ReportedUser = bug.bg_reported_user,
                    RequestOwner = bug.Bildiren,
                    ShortDesc = bug.bg_short_desc,
                    Status = bug.bg_status,
                    UpdateOn = bug.bg_last_updated_date
                });
            }
            grdBTBugs.DataSource = _bugsModels;
        }

        private void btnTransferSelectedBugs_Click(object sender, EventArgs e)
        {

            session = jsch.getSession(ConfigurationSettings.AppSettings["sshUsername"].ToString(CultureInfo.InvariantCulture), ConfigurationSettings.AppSettings["sshHost"], Convert.ToInt32(ConfigurationSettings.AppSettings["sshPort"]));

            var result = _bugsModels.Where(w => w.IsSelected).ToList();
            if (result.Any())
            {
                UserInfo ui = new ScpTo.MyUserInfo();
                session.setUserInfo(ui);
                session.connect();

                foreach (var bugModel in result)
                {
                    var bugPosts = _bugTrackerEntities.bug_posts.Where(w => w.bp_bug == bugModel.BugId).ToList();
                    foreach (var bugPost in bugPosts)
                    {
                        var bugPostAttachments = _bugTrackerEntities.bug_post_attachments.Where(w => w.bpa_post == bugPost.bp_id).ToList();
                        foreach (var bugPostAttachment in bugPostAttachments)
                        {
                            var extension = string.Empty;
                            string fileName;

                            var splits = bugPost.bp_file.Split('.');
                            if (splits.Count() > 1)
                                extension = splits[1];
                            else
                                Debug.WriteLine(bugPost.bp_file);

                            if (!string.IsNullOrEmpty(extension))
                                fileName = bugPostAttachment.bpa_id.ToString(CultureInfo.InvariantCulture) + "." + extension;
                            else
                                fileName = bugPostAttachment.bpa_id.ToString(CultureInfo.InvariantCulture);

                            var localPath = ConfigurationSettings.AppSettings["sshLocalPath"].ToString(CultureInfo.InvariantCulture) + fileName;
                            var remotePath = (ConfigurationSettings.AppSettings["sshRemotePath"].ToString(CultureInfo.InvariantCulture) + "/" + fileName).ToString(CultureInfo.InvariantCulture);

                            if (string.IsNullOrEmpty(fileName))
                            {
                                Debug.WriteLine("file name is empty : " + fileName);
                                continue;
                            }

                            using (var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write))
                                fs.Write(bugPostAttachment.bpa_content, 0, bugPostAttachment.bpa_content.Length);

                            lstAdd(fileName + " file transfering");
                            FileUpload(remotePath, localPath);
                            lstAdd(fileName + " processed");
                        }
                    }
                }
            }
        }

        static int checkAck(Stream ins)
        {
            Console.Write(".");
            int b = ins.ReadByte();
            Console.Write(".");
            // b may be 0 for success,
            //          1 for error,
            //          2 for fatal error,
            //          -1
            if (b == 0) return b;
            if (b == -1) return b;

            if (b == 1 || b == 2)
            {
                StringBuilder sb = new StringBuilder();
                int c;
                do
                {
                    c = ins.ReadByte();
                    sb.Append((char)c);
                }
                while (c != '\n');
                if (b == 1)
                { // error
                    Console.Write(sb.ToString());
                }
                if (b == 2)
                { // fatal error
                    Console.Write(sb.ToString());
                }
            }
            return b;
        }

        private void FileUpload(string remoteFile, string localFile)
        {
            try
            {
                String command = "scp -p -t " + remoteFile;
                Channel channel = session.openChannel("exec");
                ((ChannelExec)channel).setCommand(command);

                // get I/O streams for remote scp
                Stream outs = channel.getOutputStream();
                Stream ins = channel.getInputStream();

                channel.connect();

                if (checkAck(ins) != 0)
                {
                    //Environment.Exit(0);
                }

                // send "C0644 filesize filename", where filename should not include '/'

                int filesize = (int)(new FileInfo(localFile)).Length;
                command = "C0644 " + filesize + " ";
                if (localFile.LastIndexOf('/') > 0)
                {
                    command += localFile.Substring(localFile.LastIndexOf('/') + 1);
                }
                else
                {
                    command += localFile;
                }
                command += "\n";
                byte[] buff = Util.getBytes(command);
                outs.Write(buff, 0, buff.Length); outs.Flush();

                if (checkAck(ins) != 0)
                {
                    //Environment.Exit(0);
                }


                // send a content of lfile
                FileStream fis = File.OpenRead(localFile);
                byte[] buf = new byte[1024];
                //var prg = string.Empty;
                while (true)
                {
                    int len = fis.Read(buf, 0, buf.Length);
                    if (len <= 0) break;
                    outs.Write(buf, 0, len); outs.Flush();
                    Debug.Write("#");
                    //prg += "#";
                }
                //lstAdd(prg);

                // send '\0'
                buf[0] = 0; outs.Write(buf, 0, 1); outs.Flush();
                Debug.Write(".");

                if (checkAck(ins) != 0)
                {
                    //Environment.Exit(0);
                }

                //lstAdd(localFile + " file transfered " + remoteFile);

                Debug.WriteLine("OK");
                //Environment.Exit(0);

                channel.disconnect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //lstAdd(ex.Message);
            }
        }

        private void lstAdd(string text)
        {
            lstConsole.Items.Add(text);
            lstConsole.SelectedIndex = lstConsole.Items.Count - 1;
            lstConsole.Refresh();
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            lstConsole.Items.Clear();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_bugsModels.Any())
                foreach (var bugsModel in _bugsModels)
                {
                    bugsModel.IsSelected = chkSelectAll.Checked;
                }
            grdBTBugs.Refresh();
        }
    }

    public class BugModel
    {
        public bool IsSelected { get; set; }
        public int BugId { get; set; }
        public string ShortDesc { get; set; }
        public int ReportedUser { get; set; }
        public DateTime ReportedDate { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Category { get; set; }
        public int? AssignedUser { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string RequestOwner { get; set; }
        public string Description { get; set; }
    }
}
