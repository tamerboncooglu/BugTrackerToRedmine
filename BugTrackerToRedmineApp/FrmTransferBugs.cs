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
using RedmineLibrary;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.jsch.examples;
using users = RedmineLibrary.users;

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
        readonly redmineEntities _redmineEntities = new redmineEntities();
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
            foreach (var bug in _bugTrackerEntities.bugs.ToList().Where(w => w.bg_project == 5 || w.bg_project == 9))
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
                    Notifier = bug.Bildiren,
                    ShortDesc = bug.bg_short_desc,
                    Status = bug.bg_status,
                    UpdateOn = bug.bg_last_updated_date,
                    Project = bug.bg_project,
                    Module= bug.bg_project_custom_dropdown_value1,
                    IsUpdateRequired = bug.bg_project_custom_dropdown_value2
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
                    var issue = new issues();

                    users redmineUser = null;

                    var asgnUser = _bugTrackerEntities.users.FirstOrDefault(w => w.us_id == bugModel.AssignedUser);
                    if (asgnUser != null)
                        redmineUser = _redmineEntities.users.FirstOrDefault(w => w.mail == asgnUser.us_email);
                    var authUser = _bugTrackerEntities.users.FirstOrDefault(w => w.us_id == bugModel.ReportedUser);

                    if (redmineUser != null) issue.assigned_to_id = redmineUser.id;
                    else
                    {
                        issue.assigned_to_id = 0;
                    }

                    redmineUser = _redmineEntities.users.FirstOrDefault(w => w.mail == authUser.us_email);

                    if (redmineUser != null) issue.author_id = redmineUser.id;

                    switch (bugModel.Category)
                    {
                        case 1: issue.category_id = _redmineEntities.issue_categories.FirstOrDefault(w => w.name == "Bug").id;
                            break;
                        case 3: issue.category_id = _redmineEntities.issue_categories.FirstOrDefault(w => w.name == "Feature").id;
                            break;
                        case 6: issue.category_id = _redmineEntities.issue_categories.FirstOrDefault(w => w.name == "Support").id;
                            break;
                        case 7: issue.category_id = _redmineEntities.issue_categories.FirstOrDefault(w => w.name == "Gereksiz").id;
                            break;
                    }

                    issue.created_on = bugModel.ReportedDate;
                    issue.description = bugModel.Description;
                    issue.description = bugModel.Description;

                    switch (bugModel.Priority)
                    {
                        case 1: issue.priority_id = _redmineEntities.enumerations.FirstOrDefault(w => w.name == "High").id;
                            break;
                        case 2: issue.priority_id = _redmineEntities.enumerations.FirstOrDefault(w => w.name == "Normal").id;
                            break;
                        case 3: issue.priority_id = _redmineEntities.enumerations.FirstOrDefault(w => w.name == "Low").id;
                            break;
                        case 4: issue.priority_id = _redmineEntities.enumerations.FirstOrDefault(w => w.name == "Urgent").id;
                            break;
                    }

                    switch (bugModel.Project)
                    {
                        case 5: issue.project_id = _redmineEntities.projects.FirstOrDefault(w => w.name == "MillNET").id;
                            break;
                        case 9: issue.project_id = _redmineEntities.projects.FirstOrDefault(w => w.name == "MillDOST").id;
                            break;
                    }

                    //var bugRelation = _bugTrackerEntities.bug_relationships.FirstOrDefault(w => w.re_bug1 == bugModel.BugId);

                    //if (bugRelation != null)
                    //    issue.root_id = bugRelation.re_bug2;

                    switch (bugModel.Project)
                    {
                        case 1: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "New").id;
                            break;
                        case 2: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "In Progress").id;
                            break;
                        case 4: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Feedback").id;
                            break;
                        case 5: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Resolved").id;
                            break;
                        case 6: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Rejected").id;
                            break;
                        case 7: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Resolved").id;
                            break;
                        case 8: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Closed").id;
                            break;
                        case 10: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Not Repeated").id;
                            break;
                        case 11: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Pending Reply").id;
                            break;
                        case 12: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Publish").id;
                            break;
                        case 13: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Feedback").id;
                            break;
                        case 14: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Closed").id;
                            break;
                        case 15: issue.status_id = _redmineEntities.issue_statuses.FirstOrDefault(w => w.name == "Bid Required").id;
                            break;
                    }

                    issue.subject = bugModel.ShortDesc + "(" + bugModel.BugId + ")";
                    issue.tracker_id = issue.category_id.HasValue ? issue.category_id.Value : 1;
                    issue.updated_on = bugModel.UpdateOn;
                    issue.source_id = bugModel.BugId;
                    issue.lft = 1;
                    issue.rgt = 2;

                    _redmineEntities.issues.Add(issue);
                    _redmineEntities.SaveChanges();

                    issue = _redmineEntities.issues.FirstOrDefault(w => w.source_id == bugModel.BugId);
                    issue.root_id = issue.id;

                    if (string.IsNullOrEmpty(bugModel.Notifier))
                    {
                        custom_values custom = new custom_values();
                        custom.custom_field_id = _redmineEntities.custom_fields.FirstOrDefault(w => w.name == "Notifier").id;
                        custom.customized_id = issue.id;
                        custom.customized_type = "Issue";
                        custom.value = bugModel.Notifier;
                        _redmineEntities.custom_values.Add(custom);
                        _redmineEntities.SaveChanges();
                    }

                    if (string.IsNullOrEmpty(bugModel.IsUpdateRequired))
                    {
                        custom_values custom = new custom_values();
                        custom.custom_field_id = _redmineEntities.custom_fields.FirstOrDefault(w => w.name == "Publish Required").id;
                        custom.customized_id = issue.id;
                        custom.customized_type = "Issue";
                        custom.value = "1";
                        _redmineEntities.custom_values.Add(custom);
                        _redmineEntities.SaveChanges();
                    }

                    if (string.IsNullOrEmpty(bugModel.Module))
                    {
                        custom_values custom = new custom_values();
                        if (bugModel.Project == 5)
                            custom.custom_field_id = _redmineEntities.custom_fields.FirstOrDefault(w => w.name == "MillNET Module").id;
                        if (bugModel.Project == 9)
                            custom.custom_field_id = _redmineEntities.custom_fields.FirstOrDefault(w => w.name == "MillDOST Module").id;

                        custom.customized_id = issue.id;
                        custom.customized_type = "Issue";
                        custom.value = bugModel.Module;
                        _redmineEntities.custom_values.Add(custom);
                        _redmineEntities.SaveChanges();
                    }

                    var bugPosts = _bugTrackerEntities.bug_posts.Where(w => w.bp_bug == bugModel.BugId).ToList();
                    foreach (var bugPost in bugPosts)
                    {
                        journals journal = new journals();
                        journal.notes = bugPost.bp_comment;

                        if (journal.notes.StartsWith("changed status from"))
                        {
                            journal.notes = journal.notes.Replace("Yeni", "New");
                            journal.notes = journal.notes.Replace("Yapılıyor", "In Progress");
                            journal.notes = journal.notes.Replace("Test Onaylanmadı", "Feedback");
                            journal.notes = journal.notes.Replace("Tamamlandı", "Resolved");
                            journal.notes = journal.notes.Replace("Kabul Edilmedi", "Rejected");
                            journal.notes = journal.notes.Replace("Test Ediliyor", "Resolved");
                            journal.notes = journal.notes.Replace("Test Onaylandı", "Closed");
                            journal.notes = journal.notes.Replace("Oluşturulamadı", "Not Repeated");
                            journal.notes = journal.notes.Replace("Cevap Bekleniyor", "Pending Reply");
                            journal.notes = journal.notes.Replace("Yayınlandı", "Publish");
                            journal.notes = journal.notes.Replace("Yayın Onaylanmadı", "Feedback");
                            journal.notes = journal.notes.Replace("Yayın Onaylandı", "Closed");
                            journal.notes = journal.notes.Replace("Teklif Gerekiyor", "Bid Required");
                        }
                        
                        journal.created_on = bugPost.bp_date;
                        journal.journalized_id = issue.id;
                        journal.journalized_type = "Issue";
                        journal.user_id = redmineUser.id;
                        journal.private_notes = false;
                        journal.source_id = bugPost.bp_id;
                        _redmineEntities.journals.Add(journal);
                        _redmineEntities.SaveChanges();

                        var bugPostAttachments = _bugTrackerEntities.bug_post_attachments.Where(w => w.bpa_post == bugPost.bp_id).ToList();
                        foreach (var bugPostAttachment in bugPostAttachments)
                        {
                            journal = _redmineEntities.journals.FirstOrDefault(w => w.source_id == bugPost.bp_id);

                            journal_details journalDetail = new journal_details();
                            journalDetail.journal_id = journal.id;
                            journalDetail.property = "attachment";

                            var extension = string.Empty;
                            string fileName;

                            var splits = bugPost.bp_file.Split('.');
                            if (splits.Count() > 1)
                                extension = splits[1];
                            else
                                Debug.WriteLine(bugPost.bp_file);

                            if (!string.IsNullOrEmpty(extension))
                                fileName = bugPost.bp_id.ToString(CultureInfo.InvariantCulture) + "." + extension;
                            else
                                fileName = bugPost.bp_id.ToString(CultureInfo.InvariantCulture);

                            var localPath = ConfigurationSettings.AppSettings["sshLocalPath"].ToString(CultureInfo.InvariantCulture) + fileName;
                            var remotePath = (ConfigurationSettings.AppSettings["sshRemotePath"].ToString(CultureInfo.InvariantCulture) + "/" + fileName).ToString(CultureInfo.InvariantCulture);

                            if (string.IsNullOrEmpty(fileName))
                            {
                                Debug.WriteLine("file name is empty : " + fileName);
                                continue;
                            }

                            using (var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write))
                                fs.Write(bugPostAttachment.bpa_content, 0, bugPostAttachment.bpa_content.Length);

                            journalDetail.value = fileName;
                            journalDetail.prop_key = "1";
                            _redmineEntities.journal_details.Add(journalDetail);

                            attachments attachment = new attachments();
                            attachment.author_id = redmineUser.id;
                            attachment.container_id = issue.id;
                            attachment.container_type = "Issue";
                            attachment.created_on = issue.created_on;
                            attachment.description = "";
                            attachment.digest = Guid.NewGuid().ToString();
                            attachment.disk_directory =
                                ConfigurationSettings.AppSettings["sshRemotePath"].ToString(CultureInfo.InvariantCulture);
                            attachment.disk_filename = fileName;
                            attachment.filename = fileName;
                            attachment.filesize = bugPostAttachment.bpa_content.Length;
                            attachment.downloads = 0;
                            _redmineEntities.attachments.Add(attachment);
                            _redmineEntities.SaveChanges();
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
        public string Notifier { get; set; }
        public string Description { get; set; }
        public int Project { get; set; }
        public string Module { get; set; }
        public string IsUpdateRequired { get; set; }
    }
}
