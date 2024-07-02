using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTOs;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Services.Contracts;

public interface IBoardService
{
    List<ListBoardWithIdandTitleDTO> GetAllBoardsWithIdsandTitlesByProjectId(Guid projectId);
    bool HasBoardByProjectId(Guid projectId);
    Board GetOneBoardByBoardId(Guid boardId);
}