using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.DTOs;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class GetDetailsOneBoardViewModel
    {
        public List<StageDto> stageDtos { get; set; }
    }
}