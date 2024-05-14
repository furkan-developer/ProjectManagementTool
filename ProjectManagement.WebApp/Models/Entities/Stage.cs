namespace ProjectManagement.WebApp.Models.Entities
{
    public class Stage : EntityBase
    {
        public string StageName { get; set; }
        public string Description { get; set; }

        public Guid BoardId { get; set; }
        public Board Board { get; set; }    

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
