using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.DTOs;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class GetDetailsOneBoardViewModel
    {
        public Guid BoardId { get; set; }
        public List<StageDto> stageDtos { get; set; }
    }
}