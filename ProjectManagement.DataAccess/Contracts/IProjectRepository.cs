using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface IProjectRepository
    {
        bool HasProject(Expression<Func<Project, bool>> expression);
        Project? GetOneProject(Expression<Func<Project, bool>> expression);
        IEnumerable<Project> GetAllProjects(bool trackChanges = false);
        IEnumerable<Project> GetAllProjectsByCondition(Expression<Func<Project, bool>> expression, bool trackChanges = false);
        void CreateOneProject(Project entity);
        void UpdateOneProject(Project entity);
        void DeleteOneProject(Project entity);
    }
}