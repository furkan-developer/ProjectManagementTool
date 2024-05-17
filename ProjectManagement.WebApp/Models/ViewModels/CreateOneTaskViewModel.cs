using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class CreateOneTaskViewModel
    {
        public CreateOneTaskViewModel()
        {
            Assignments = new List<UserAssignmentViewModel>();
        }

        [MinLength(length: 3, ErrorMessage = "Title must be min 3 lenght")]
        public string Title { get; set; }

        public string Description { get; set; }

        // [DataType(DataType.Date)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        // public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DueDate { get; set; }
        public JobPriority Priority { get; set; }

        public Guid StageId { get; set; }

        public List<UserAssignmentViewModel> Assignments { get; set; }
    }
}