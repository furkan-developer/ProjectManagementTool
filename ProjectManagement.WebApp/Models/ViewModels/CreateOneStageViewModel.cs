using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class CreateOneStageViewModel
    {
        [Required]
        public Guid BoardId { get; set; }

        [Required]
        public string StageName { get; set; }
    }
}