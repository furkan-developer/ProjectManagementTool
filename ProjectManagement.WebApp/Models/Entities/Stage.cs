namespace ProjectManagement.WebApp.Models.Entities
{
    public class Stage : EntityBase
    {
        public string StageName { get; set; }
        public string Description { get; set; }


        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
