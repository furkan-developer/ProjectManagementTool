namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class AssignRoleViewModel
    {
        public Guid RoleId { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public bool IsAssigned { get; set; }
    }
}
