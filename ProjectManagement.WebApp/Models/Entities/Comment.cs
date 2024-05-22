using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.WebApp.Models.Identity;

namespace ProjectManagement.WebApp.Models.Entities
{
    public class Comment : EntityBase
    {
        public string Content { get; set; }
        
        
        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }
        
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}