namespace BugTrackerToRedmineApp.Model
{
    public class StatusModel
    {
        public bool IsSelected { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int? Position { get; set; }
        public int Default { get; set; }
    }
}