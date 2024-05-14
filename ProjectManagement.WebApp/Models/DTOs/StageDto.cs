using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.DTOs
{
    public class StageDto
    {
          public string StageName { get; set; }
          public List<JobDTO> jobDTOs { get; set; }
    }
}