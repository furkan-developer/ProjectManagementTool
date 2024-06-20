namespace ProjectManagement.Domain.DTOs;

public class StageDto
{
    public Guid StageId { get; set; }
    public string StageName { get; set; }
    public List<JobDTO> JobDTOs { get; set; }
}