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
using projects = RedmineLibrary.projects;

namespace BugTrackerToRedmineApp
{
    public partial class FrmTransferProjects : Form
    {
        public FrmTransferProjects()
        {
            InitializeComponent();
        }

        readonly List<ProjectModel> _projectModels = new List<ProjectModel>();
        readonly BugTrackerEntities _bugTrackerEntities = new BugTrackerEntities();
        readonly redmineEntities _redmineEntities = new redmineEntities();

        private void FrmTransferProjects_Load(object sender, EventArgs e)
        {
            GetBTProjects();

            GetRedmineProjects();

            grdBTProjects.ReadOnly = false;
            for (int i = 0; i < grdBTProjects.Columns.Count; i++)
            {
                if (grdBTProjects.Columns[i] != null)
                    grdBTProjects.Columns[i].ReadOnly = true;
            }

            grdBTProjects.Columns["IsSelected"].ReadOnly = false;
        }

        private void GetBTProjects()
        {
            foreach (var project in _bugTrackerEntities.projects.ToList())
            {
                _projectModels.Add(new ProjectModel
                {
                    ProjectId = project.pj_id,
                    Name = project.pj_name,
                    Description = project.pj_description,
                    Active = project.pj_active
                });
            }
            grdBTProjects.DataSource = _projectModels;
        }

        private void GetRedmineProjects()
        {
            var projectModelsRedmine = new List<ProjectModel>();
            foreach (var project in _redmineEntities.projects.ToList())
            {
                projectModelsRedmine.Add(new ProjectModel
                {
                    Description = project.description,
                    ProjectId = project.id,
                    Name = project.name,
                    Active = project.status
                });
            }
            grdRProjects.DataSource = projectModelsRedmine;
        }

        private void btnTransferSelectedProjects_Click(object sender, EventArgs e)
        {
            var result = _projectModels.Where(w => w.IsSelected).ToList();
            if (result.Any())
            {
                foreach (var projectModel in result)
                {
                    if (!_redmineEntities.projects.Any(w => w.name == projectModel.Name))
                    {
                        _redmineEntities.projects.Add(new projects
                        {
                            created_on = DateTime.Now,
                            name = projectModel.Name,
                            description = projectModel.Description,
                            is_public = true,
                            identifier = projectModel.Name.ToLower().Replace("","-"),
                            status = projectModel.Active,
                            lft = 1,
                            rgt = 1,
                            inherit_members = false
                        });
                        try
                        {
                            _redmineEntities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(@"Exception throw : " + ex.Message);
                        }

                        MessageBox.Show(@"Project/Projects Added");
                        GetRedmineProjects();
                    }
                    else
                    {
                        MessageBox.Show(@"Project Already Exist");
                    }
                }
            }
        }
    }
}
