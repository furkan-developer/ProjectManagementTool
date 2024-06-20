using ProjectManagement.Domain.Entities.AspIdentity;

namespace ProjectManagement.Domain.Entities;

public class BoardUserAssociation
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Guid BoardId { get; set; }
    public Board Board { get; set; }

}