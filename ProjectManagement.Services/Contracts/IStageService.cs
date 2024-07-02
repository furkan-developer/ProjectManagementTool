using ProjectManagement.Domain.DTOs;
namespace ProjectManagement.Services.Contracts;

public interface IStageService
{
    List<ListStageWithJobsDTO> GetAllStagesWithJobs(Guid boardId);
}
