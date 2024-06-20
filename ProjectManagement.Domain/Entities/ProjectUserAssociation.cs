using ProjectManagement.Domain.Entities.AspIdentity;

namespace ProjectManagement.Domain.Entities;

public class ProjectUserAssociation
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; }
}
