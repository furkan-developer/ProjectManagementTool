using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts;

public interface IRepositoryBase<T> where T : EntityBase
{
    // TODO: has method implementation
    bool Has(Expression<Func<T, bool>> expression);
    T? GetOne(Expression<Func<T, bool>> expression);
    IQueryable<T> GetAll(bool trackChanges = false);
    IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}