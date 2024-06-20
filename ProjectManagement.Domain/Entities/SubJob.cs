namespace ProjectManagement.Domain.Entities;

public class SubJob : EntityBase
{
    public string Title { get; set; }
    public bool IsComplete { get; set; }

    public Guid JobId { get; set; }
    public Job Job { get; set; }
}