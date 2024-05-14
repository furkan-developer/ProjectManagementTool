using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.DTOs
{
    public class JobDTO
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public JobPriority Priority { get; set; }
    }
}