using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BugTrackerLibrary;
using BugTrackerToRedmineApp.Model;
using RedmineLibrary;

namespace BugTrackerToRedmineApp
{
    public partial class FrmTransferStatuses : Form
    {
        public FrmTransferStatuses()
        {
            InitializeComponent();
        }

        readonly List<StatusModel> _statusModels = new List<StatusModel>();
        readonly BugTrackerEntities _bugTrackerEntities = new BugTrackerEntities();
        readonly redmineEntities _redmineEntities = new redmineEntities();

        private void FrmTransferStatuses_Load(object sender, EventArgs e)
        {
            GetBTStatuses();

            GetRedmineStatuses();

            grdBTStatuses.ReadOnly = false;
            for (int i = 0; i < grdBTStatuses.Columns.Count; i++)
            {
                if (grdBTStatuses.Columns[i] != null)
                    grdBTStatuses.Columns[i].ReadOnly = true;
            }

            grdBTStatuses.Columns["IsSelected"].ReadOnly = false;
        }

        private void GetRedmineStatuses()
        {
            var statusModelsRedmine = new List<StatusModel>();
            foreach (var status in _redmineEntities.issue_statuses.ToList())
            {
                statusModelsRedmine.Add(new StatusModel
                {
                    Position = status.position,
                    StatusID = status.id,
                    StatusName = status.name,
                    Default = status.is_default ? 1 : 0
                });
            }
            grdRStatuses.DataSource = statusModelsRedmine;
        }

        private void GetBTStatuses()
        {
            foreach (var status in _bugTrackerEntities.statuses.ToList())
            {
                _statusModels.Add(new StatusModel
                {
                    StatusID = status.st_id,
                    StatusName = status.st_name,
                    Position = status.st_sort_seq,
                    Default = status.st_default
                });
            }
            grdBTStatuses.DataSource = _statusModels;
        }

        private void btnTransferSelectedStatuses_Click(object sender, EventArgs e)
        {
            var result = _statusModels.Where(w => w.IsSelected).ToList();
            if (result.Any())
            {
                foreach (var statusModel in result)
                {
                    if (!_redmineEntities.issue_statuses.Any(w => w.id == statusModel.StatusID))
                    {
                        _redmineEntities.issue_statuses.Add(new issue_statuses
                        {
                            is_closed = false,
                            is_default = statusModel.Default > 0,
                            name = statusModel.StatusName,
                            position = statusModel.Position});
                        try
                        {
                            _redmineEntities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(@"Exception throw : " + ex.Message);
                        }

                        MessageBox.Show(@"Status/Statuses Added");
                        GetRedmineStatuses();
                    }
                    else
                    {
                        MessageBox.Show(@"Status Already Exist");
                    }
                }
            }
        }
    }
}
