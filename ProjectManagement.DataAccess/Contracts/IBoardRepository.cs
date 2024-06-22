using System.Linq.Expressions;
using ProjectManagement.Domain.DTOs;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.DataAccess.Contracts
{
    public interface IBoardRepository
    {
        bool HasBoard(Expression<Func<Board, bool>> expression);
        Board? GetOneBoard(Expression<Func<Board, bool>> expression);
        IEnumerable<ListBoardWithIdandTitleDTO> GetAllBoardsWithIdsandTitlesByProjectId(Guid projectId);
        IEnumerable<Board> GetAllBoards(bool trackChanges = false);
        IEnumerable<Board> GetAllBoardsByCondition(Expression<Func<Board, bool>> expression, bool trackChanges = false);
        void CreateOneBoard(Board entity);
        void UpdateOneBoard(Board entity);
        void DeleteOneBoard(Board entity);
    }
}