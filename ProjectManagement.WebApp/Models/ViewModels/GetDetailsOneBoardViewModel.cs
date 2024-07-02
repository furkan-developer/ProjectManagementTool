using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.Domain.DTOs;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class GetDetailsOneBoardViewModel
    {
        public Guid BoardId { get; set; }
        public string BoardName { get; set; }
        public List<ListStageWithJobsDTO> stageDtos { get; set; }
    }
}