using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.WebApp.Models.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public DateTime CreatedOn { get; set; }
    }
}