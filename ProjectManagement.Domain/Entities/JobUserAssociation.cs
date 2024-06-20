using ProjectManagement.Domain.Entities.AspIdentity;

namespace ProjectManagement.Domain.Entities;

public class JobUserAssociation
{
    public Guid UserId { get; set; }
    public AppUser User { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; }
}