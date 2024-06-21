using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface ISubJobRepository
    {
        bool HasSubJob(Expression<Func<SubJob, bool>> expression);
        SubJob? GetOneSubJob(Expression<Func<SubJob, bool>> expression);
        IEnumerable<SubJob> GetAllSubJobs(bool trackChanges = false);
        IEnumerable<SubJob> GetAllSubJobsByCondition(Expression<Func<SubJob, bool>> expression, bool trackChanges = false);
        void CreateOneSubJob(SubJob entity);
        void UpdateOneSubJob(SubJob entity);
        void DeleteOneSubJob(SubJob entity);
    }
}