namespace ProjectManagement.Domain.DTOs;

public class UpdateStageOfOneTaskDto
{
    public Guid FromStage { get; set; }
    public Guid ToStage { get; set; }
    public Guid TaskId { get; set; }
}