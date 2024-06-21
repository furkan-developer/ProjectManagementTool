using System.Linq.Expressions;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface ICommentRepository
    {
        bool HasComment(Expression<Func<Comment, bool>> expression);
        Comment? GetOneComment(Expression<Func<Comment, bool>> expression);
        IEnumerable<Comment> GetAllComments(bool trackChanges = false);
        IEnumerable<Comment> GetAllCommentsByCondition(Expression<Func<Comment, bool>> expression, bool trackChanges = false);
        void CreateOneComment(Comment entity);
        void UpdateOneComment(Comment entity);
        void DeleteOneComment(Comment entity);
    }
}