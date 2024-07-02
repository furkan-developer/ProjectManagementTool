using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.DTOs
{
    public class ListStageWithJobsDTO
    {
        public Guid StageId { get; set; }
        public string StageName { get; set; }
        public List<JobDTO> JobDTOs { get; set; }
    }
}