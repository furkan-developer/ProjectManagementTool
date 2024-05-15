using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.DTOs
{
    public class UpdateStageOfOneTaskDto
    {
        public Guid FromStage { get; set; }
        public Guid ToStage { get; set; }
        public Guid TaskId { get; set; }
    }
}