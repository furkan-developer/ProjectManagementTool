using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.DTOs;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Exceptions.ResourceNotFound;
using ProjectManagement.Services.Contracts;

namespace ProjectManagement.Services.Services
{
    public class BoardService(IUnitOfWork unitOfWork, IProjectService projectServices) : IBoardService
    {
        public List<ListBoardWithIdandTitleDTO> GetAllBoardsWithIdsandTitlesByProjectId(Guid projectId)
        {
            projectServices.HasProjectById(projectId);
            
            var boards = unitOfWork.BoardRepository.GetAllBoardsWithIdsandTitlesByProjectId(projectId);

            return boards.ToList();
        }

        public Board GetOneBoardByBoardId(Guid boardId) {
            
           bool hasBoard = unitOfWork.BoardRepository.HasBoard(b => b.Id == boardId);
            if(!hasBoard)
                throw new BoardNotFoundException();

            return unitOfWork.BoardRepository.GetOneBoard(b => b.Id == boardId);
        }
    
        public bool HasBoardByProjectId(Guid projectId) => unitOfWork.BoardRepository.HasBoard(b => b.Id == projectId) ? true : throw new BoardNotFoundException();
    }
}