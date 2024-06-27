using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Exceptions.ResourceNotFound;
using ProjectManagement.Services.Contracts;

namespace ProjectManagement.Services.Services
{
    public class ProjectService(IUnitOfWork unitOfWork) : IProjectService
    {
        public string GetNameOfProjectById(Guid projectId)
        {
            HasProjectById(projectId);

            var project = unitOfWork.ProjectRepository.GetOneProject(b => b.Id == projectId);
            return project.ProjectName;
        }

        public void HasProjectById(Guid projectId)
        {
            bool hasProject = unitOfWork.ProjectRepository.HasProject(p => p.Id == projectId);
            if (!hasProject)
                throw new ProjectNotFoundException();
        }
    }
}