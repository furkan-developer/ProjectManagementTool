using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.DTOs;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class CreateOneBoardViewModel
    {
        public CreateOneBoardViewModel()
        {
            Assignments = new List<UserAssignmentViewModel>();
        }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public Guid WorkspaceId { get; set; }

        public List<CreateStageDTO> Stages { get; set; }
        public List<UserAssignmentViewModel> Assignments { get; set; }
    }
}