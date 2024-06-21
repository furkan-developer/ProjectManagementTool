using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface IJobRepository
    {
        bool HasJob(Expression<Func<Job, bool>> expression);
        Job? GetOneJob(Expression<Func<Job, bool>> expression);
        IEnumerable<Job> GetAllJobs(bool trackChanges = false);
        IEnumerable<Job> GetAllJobsByCondition(Expression<Func<Job, bool>> expression, bool trackChanges = false);
        void CreateOneJob(Job entity);
        void UpdateOneJob(Job entity);
        void DeleteOneJob(Job entity);
    }
}