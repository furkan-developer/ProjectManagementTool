using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.Domain.Entities.AspIdentity;

public class AppRole : IdentityRole<Guid>
{
    public DateTime CreatedOn { get; set; }
}