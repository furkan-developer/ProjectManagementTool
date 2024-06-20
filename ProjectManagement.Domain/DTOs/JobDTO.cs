namespace ProjectManagement.Domain.DTOs;

public class JobDTO
{
    public Guid JobId { get; set; }
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public JobPriority Priority { get; set; }
    public bool IsComplete { get; set; }
    public List<string> Assignments { get; set; }
}