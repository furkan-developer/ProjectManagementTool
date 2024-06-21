using System.Linq.Expressions;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface IStageRepository
    {
        bool HasStage(Expression<Func<Stage, bool>> expression);
        Stage? GetOneStage(Expression<Func<Stage, bool>> expression);
        IEnumerable<Stage> GetAllStages(bool trackChanges = false);
        IEnumerable<Stage> GetAllStagesByCondition(Expression<Func<Stage, bool>> expression, bool trackChanges = false);
        void CreateOneStage(Stage entity);
        void UpdateOneStage(Stage entity);
        void DeleteOneStage(Stage entity);
    }
}