using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Domain.DTOs;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Services.Contracts;

namespace ProjectManagement.Services.Services
{
    public class BoardService(IUnitOfWork unitOfWork, IProjectService projectServices) : IBoardService
    {
        public List<ListBoardWithIdandTitleDTO> GetAllBoardsWithIdsandTitlesByProjectId(Guid projectId)
        {
            bool hasProject = projectServices.HasProjectById(projectId);
            if (!hasProject)
                throw new Exception("Relevent project was not found");

            var boards = unitOfWork.BoardRepository.GetAllBoardsWithIdsandTitlesByProjectId(projectId);

            return boards.ToList();
        }
    }
}