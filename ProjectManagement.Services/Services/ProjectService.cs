using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Services.Contracts;

namespace ProjectManagement.Services.Services
{
    public class ProjectService(IUnitOfWork unitOfWork) : IProjectService
    {
        public bool HasProjectById(Guid projectId) => unitOfWork.ProjectRepository.HasProject(p => p.Id == projectId);
    }
}