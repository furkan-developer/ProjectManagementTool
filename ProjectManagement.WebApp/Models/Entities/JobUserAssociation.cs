using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Models.Entities
{
    public class JobUserAssociation
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}