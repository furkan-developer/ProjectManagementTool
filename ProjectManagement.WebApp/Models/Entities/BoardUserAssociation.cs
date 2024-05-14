using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Models.Entities
{
    public class BoardUserAssociation
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid BoardId { get; set; }
        public Board Board { get; set; }
        
    }
}