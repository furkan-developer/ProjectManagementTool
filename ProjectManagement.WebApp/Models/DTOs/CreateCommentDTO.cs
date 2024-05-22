using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.DTOs
{
    public class CreateCommentDTO
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public Guid ToJob { get; set; }
    }
}