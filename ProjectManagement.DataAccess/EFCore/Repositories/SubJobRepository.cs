using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class SubJobRepository : RepositoryBase<SubJob>, ISubJobRepository
{
    public SubJobRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneSubJob(SubJob entity) => Create(entity);

    public void DeleteOneSubJob(SubJob entity) => Delete(entity);

    public IEnumerable<SubJob> GetAllSubJobs(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<SubJob> GetAllSubJobsByCondition(Expression<Func<SubJob, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public SubJob? GetOneSubJob(Expression<Func<SubJob, bool>> expression) => GetOne(expression);

    public bool HasSubJob(Expression<Func<SubJob, bool>> expression) => Has(expression);

    public void UpdateOneSubJob(SubJob entity) => Update(entity);

}