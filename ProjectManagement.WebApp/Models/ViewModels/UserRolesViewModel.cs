namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public string Id { get; set; } = default!;
        public List<AssignRoleViewModel> Roles { get; set; } = new();
    }
}
