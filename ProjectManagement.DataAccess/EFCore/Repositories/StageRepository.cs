using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.DTOs;
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

    public IEnumerable<ListStageWithJobsDTO> GetAllStagesWithJobsByBoardId(Guid boardId, bool trackChanges = false) => 
      GetAllByCondition(s => s.BoardId == boardId,trackChanges)
            .OrderBy(s => s.CreatedOn)
            .Select(s => new ListStageWithJobsDTO()
            {
                StageId = s.Id,
                StageName = s.StageName,
                JobDTOs = s.Jobs.Select(j => new JobDTO()
                {
                    JobId = j.Id,
                    DueDate = j.DueDate,
                    Title = j.Title,
                    Priority = j.Priority,
                    Assignments = j.Users.Select(a => $"{a.User.FirstName} {a.User.LastName}").ToList(),
                    IsComplete = j.IsComplete
                }).ToList()
            })
            .ToList();

    public Stage? GetOneStage(Expression<Func<Stage, bool>> expression) => GetOne(expression);

    public bool HasStage(Expression<Func<Stage, bool>> expression) => Has(expression);

    public void UpdateOneStage(Stage entity) => Update(entity);

}