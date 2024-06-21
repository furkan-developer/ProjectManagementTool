using System.Linq.Expressions;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.DataAccess.EFCore;
using ProjectManagement.Domain.Entities;

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

    public bool HasBoard(Expression<Func<Board, bool>> expression) => Has(expression);

    public void UpdateOneBoard(Board entity) => Update(entity);

}