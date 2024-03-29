using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Models.Entities
{
    public class ProjectUserAssociation
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
