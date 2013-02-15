namespace BugTrackerToRedmineApp.Model
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public bool IsSelected { get; set; }
    }
}
