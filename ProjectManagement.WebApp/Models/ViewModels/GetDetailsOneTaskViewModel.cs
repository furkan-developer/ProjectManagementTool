using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.Entities;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class GetDetailsOneTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public Guid JobId { get; set; }
        public bool IsComplete { get; set; }

        public List<ListSubTaskViewModel> SubJobs { get; set; } = new List<ListSubTaskViewModel>();
        public List<ListCommentViewModel> Comments { get; set; } = new List<ListCommentViewModel>();
    }
}