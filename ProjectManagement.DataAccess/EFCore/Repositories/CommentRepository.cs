using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneComment(Comment entity) => Create(entity);

    public void DeleteOneComment(Comment entity) => Delete(entity);

    public IEnumerable<Comment> GetAllComments(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<Comment> GetAllCommentsByCondition(Expression<Func<Comment, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public Comment? GetOneComment(Expression<Func<Comment, bool>> expression) => GetOne(expression);

    public bool HasComment(Expression<Func<Comment, bool>> expression) => Has(expression);

    public void UpdateOneComment(Comment entity) => Update(entity);

}