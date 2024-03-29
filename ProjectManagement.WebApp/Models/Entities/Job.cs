namespace ProjectManagement.WebApp.Models.Entities
{
    public class Job : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }


        public Stage? Stage { get; set; }
        public Guid? StageId { get; set; }


        public Guid ProjectId { get; set; }
        public Project Project { get; set; }


        public ICollection<Dependency> Dependencies { get; set; } = new List<Dependency>();
    }
}
