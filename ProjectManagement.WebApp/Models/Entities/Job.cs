namespace ProjectManagement.WebApp.Models.Entities
{
    public class Job : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public JobPriority Priority { get; set; }
        public string Status { get; set; }


        public Stage? Stage { get; set; }
        public Guid? StageId { get; set; }
        
        public ICollection<JobUserAssociation> Users { get; set; } = new List<JobUserAssociation>();
        public ICollection<Dependency> Dependencies { get; set; } = new List<Dependency>();
    }
}
