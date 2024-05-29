using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.DTOs
{
    public class JobDTO
    {
        public Guid JobId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public JobPriority Priority { get; set; }
        public bool IsComplete { get; set; }
        public List<string> Assignments { get; set; }
    }
}