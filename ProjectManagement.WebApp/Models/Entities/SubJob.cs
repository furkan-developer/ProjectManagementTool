using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.Entities
{
    public class SubJob : EntityBase
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }

        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}