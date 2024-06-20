﻿namespace ProjectManagement.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
