using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BugTrackerLibrary;
using BugTrackerToRedmineApp.Model;
using RedmineLibrary;
using users = RedmineLibrary.users;

namespace BugTrackerToRedmineApp
{
    public partial class FrmTransferUsers : Form
    {
        public FrmTransferUsers()
        {
            InitializeComponent();
        }

        readonly List<UserModel> _userModels = new List<UserModel>();
        readonly BugTrackerEntities _bugTrackerEntities = new BugTrackerEntities();
        readonly redmineEntities _redmineEntities = new redmineEntities();

        private void FrmTransferUsers_Load(object sender, EventArgs e)
        {
            GetBTUsers();

            GetRedmineUsers();

            grdBTUsers.ReadOnly = false;
            for (int i = 0; i < grdBTUsers.Columns.Count; i++)
            {
                if (grdBTUsers.Columns[i] != null)
                    grdBTUsers.Columns[i].ReadOnly = true;
            }

            grdBTUsers.Columns["IsSelected"].ReadOnly = false;
        }

        private void GetBTUsers()
        {
            foreach (var user in _bugTrackerEntities.users.ToList())
            {
                _userModels.Add(new UserModel
                    {
                        Email = user.us_email,
                        FirstName = user.us_firstname,
                        Admin = user.us_admin,
                        LastName = user.us_lastname,
                        Password = user.us_password,
                        Username = user.us_username,
                        Active = user.us_active
                    });
            }
            grdBTUsers.DataSource = _userModels;
        }

        private void GetRedmineUsers()
        {
            var userModelsRedmine = new List<UserModel>();
            foreach (var user in _redmineEntities.users.ToList())
            {
                userModelsRedmine.Add(new UserModel
                    {
                        Email = user.mail,
                        FirstName = user.firstname,
                        LastName = user.lastname,
                        Password = user.hashed_password,
                        Username = user.login,
                        Active = user.status,
                        Admin = user.admin ? 1 : 0
                    });
            }
            grdRUsers.DataSource = userModelsRedmine;
        }

        private void btnTransferSelectedUsers_Click(object sender, EventArgs e)
        {
            var result = _userModels.Where(w => w.IsSelected).ToList();
            if (result.Any())
            {
                foreach (var userModel in result)
                {
                    if (!_redmineEntities.users.Any(w => w.mail == userModel.Email))
                    {
                        _redmineEntities.users.Add(new users
                            {
                                admin = userModel.Admin > 0,
                                created_on = DateTime.Now,
                                firstname = userModel.FirstName,
                                hashed_password = userModel.Password,
                                lastname = userModel.LastName,
                                language = "en",
                                status = 3, //locked
                                login = userModel.Username,
                                mail = userModel.Email,
                                type = "user",
                                mail_notification = "only_my_events"
                            });
                        try
                        {
                            _redmineEntities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(@"Exception throw : " + ex.Message);
                        }

                        MessageBox.Show(@"User/Users Added");
                        GetRedmineUsers();
                    }
                    else
                    {
                        MessageBox.Show(@"User Already Exist");
                    }
                }
            }
        }
    }
}
