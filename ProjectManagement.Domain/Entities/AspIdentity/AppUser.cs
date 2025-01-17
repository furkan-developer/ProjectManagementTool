using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.Domain.Entities.AspIdentity;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public Gender Gender { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<ProjectUserAssociation> Projects { get; set; } = new List<ProjectUserAssociation>();
    public ICollection<JobUserAssociation> Jobs { get; set; } = new List<JobUserAssociation>();

    public ICollection<BoardUserAssociation> Boards { get; set; } = new List<BoardUserAssociation>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}