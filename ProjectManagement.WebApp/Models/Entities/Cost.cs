namespace ProjectManagement.WebApp.Models.Entities
{
    public class Cost : EntityBase
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }


        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
