using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore;

public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
    protected readonly AppDbContext _context;
    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public IQueryable<T> GetAll(bool trackChanges = false) =>
        !trackChanges ?
        _context.Set<T>().AsNoTracking() :
        _context.Set<T>();

    public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges = false) =>
        !trackChanges ?
        _context.Set<T>().Where(expression).AsNoTracking() :
        _context.Set<T>().Where(expression);

    public T? GetOne(Expression<Func<T, bool>> expression) =>_context.Set<T>().SingleOrDefault(expression);

    public bool Has(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);

    public void Update(T entity) => _context.Set<T>().Update(entity);
}