namespace BugTrackerToRedmineApp.Model
{
    public class UserModel
    {
        public bool IsSelected { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Admin { get; set; }
        public int Active { get; set; }
    }
}