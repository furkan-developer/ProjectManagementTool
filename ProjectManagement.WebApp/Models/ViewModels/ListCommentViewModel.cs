using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class ListCommentViewModel
    {
        public string Content { get; set; }
        public bool hasAssignmentToCurrentUser { get; set; }
        public string FromUser { get; set; }
    }
}