using ProjectManagement.Domain.Entities.AspIdentity;

namespace ProjectManagement.Domain.Entities;

public class Comment : EntityBase
{
    public string Content { get; set; }


    public Guid SenderId { get; set; }
    public AppUser Sender { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; }
}