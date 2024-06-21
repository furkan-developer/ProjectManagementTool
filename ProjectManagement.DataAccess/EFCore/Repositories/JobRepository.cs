using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class JobRepository : RepositoryBase<Job>, IJobRepository
{
    public JobRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneJob(Job entity) => Create(entity);

    public void DeleteOneJob(Job entity) => Delete(entity);

    public IEnumerable<Job> GetAllJobs(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<Job> GetAllJobsByCondition(Expression<Func<Job, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public Job? GetOneJob(Expression<Func<Job, bool>> expression) => GetOne(expression);

    public bool HasJob(Expression<Func<Job, bool>> expression) => Has(expression);

    public void UpdateOneJob(Job entity) => Update(entity);
}