using ProjectManagement.DataAccess.Contracts;
using ProjectManagement.Services.Contracts;
using ProjectManagement.Domain.DTOs;

namespace ProjectManagement.Services.Services;

public class StageService (IUnitOfWork unitOfWork,IBoardService boardService):IStageService
{
    public List<ListStageWithJobsDTO> GetAllStagesWithJobs(Guid boardId){
        boardService.HasBoardByProjectId(boardId);
        
       var stages =  unitOfWork.StageRepository.GetAllStagesWithJobsByBoardId(boardId, false).ToList();
       return stages;
    }
}
