using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneProject(Project entity) => Create(entity);

    public void DeleteOneProject(Project entity) => Delete(entity);

    public IEnumerable<Project> GetAllProjects(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<Project> GetAllProjectsByCondition(Expression<Func<Project, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public Project? GetOneProject(Expression<Func<Project, bool>> expression) => GetOne(expression);

    public bool HasProject(Expression<Func<Project, bool>> expression) => Has(expression);

    public void UpdateOneProject(Project entity) => Update(entity);
}