﻿namespace ProjectManagement.WebApp.Models.Entities
{
    public class Dependency : EntityBase
    {
        public Guid DependsOnJobId { get; set; }

        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
