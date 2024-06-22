using System.Data.Common;
using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.DTOs;

namespace ProjectManagement.DataAccess.EFCore.Repositories;

public class BoardRepository : RepositoryBase<Board>, IBoardRepository
{
    public BoardRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateOneBoard(Board entity) => Create(entity);

    public void DeleteOneBoard(Board entity) => Delete(entity);

    public IEnumerable<Board> GetAllBoards(bool trackChanges = false) => GetAll(trackChanges).ToList();

    public IEnumerable<Board> GetAllBoardsByCondition(Expression<Func<Board, bool>> expression, bool trackChanges = false) => GetAllByCondition(expression, trackChanges).ToList();

    public Board? GetOneBoard(Expression<Func<Board, bool>> expression) => GetOne(expression);

    public IEnumerable<ListBoardWithIdandTitleDTO> GetAllBoardsWithIdsandTitlesByProjectId(Guid projectId)
    {
        var boards = GetAllByCondition(b => b.ProjectId == projectId).Select(b => new ListBoardWithIdandTitleDTO()
        {
            Id = b.Id,
            Title = b.Title,
        }).ToList();

        return boards;
    }

    public bool HasBoard(Expression<Func<Board, bool>> expression) => Has(expression);

    public void UpdateOneBoard(Board entity) => Update(entity);

}