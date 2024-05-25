using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class CreateOneSubTaskViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsComplete { get; set; }
        [Required]
        public Guid TaskId { get; set; }
    }
}