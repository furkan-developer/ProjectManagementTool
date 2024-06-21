using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class StageRepository : RepositoryBase<Stage>, IStageRepository
{
    public StageRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneStage(Stage entity) => Create(entity);

    public void DeleteOneStage(Stage entity) => Delete(entity);

    public IEnumerable<Stage> GetAllStages(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<Stage> GetAllStagesByCondition(Expression<Func<Stage, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public Stage? GetOneStage(Expression<Func<Stage, bool>> expression) => GetOne(expression);

    public bool HasStage(Expression<Func<Stage, bool>> expression) => Has(expression);

    public void UpdateOneStage(Stage entity) => Update(entity);

}