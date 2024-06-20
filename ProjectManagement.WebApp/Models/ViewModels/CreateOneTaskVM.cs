using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Domain;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class CreateOneTaskVM
    {
        public string Title { get; set; }
        public string  Description { get; set; }
        public JobPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public List<Guid> Assignments { get; set; } = new List<Guid>();
        public Guid StageId { get; set; }
    }
}