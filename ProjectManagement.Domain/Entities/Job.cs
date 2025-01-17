﻿namespace ProjectManagement.Domain.Entities;

public class Job : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; }
    public JobPriority Priority { get; set; }
    public bool IsComplete { get; set; } = false;
    public Stage? Stage { get; set; }
    public Guid? StageId { get; set; }

    public ICollection<JobUserAssociation> Users { get; set; } = new List<JobUserAssociation>();
    public ICollection<Dependency> Dependencies { get; set; } = new List<Dependency>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<SubJob> SubJobs { get; set; } = new List<SubJob>();
}
