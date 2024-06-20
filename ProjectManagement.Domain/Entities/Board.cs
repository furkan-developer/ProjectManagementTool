namespace ProjectManagement.Domain.Entities;

public class Board : EntityBase
{
    public string Title { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public ICollection<Stage> Stages { get; set; } = new List<Stage>();
    public ICollection<BoardUserAssociation> Users { get; set; } = new List<BoardUserAssociation>();
}