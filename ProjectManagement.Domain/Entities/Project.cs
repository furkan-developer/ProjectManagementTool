namespace ProjectManagement.Domain.Entities;

public class Project : EntityBase
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<Board> boards { get; set; } = new List<Board>();
    public ICollection<ProjectUserAssociation> Users { get; set; } = new List<ProjectUserAssociation>();
    public ICollection<Cost> Costs { get; set; } = new List<Cost>();
}
