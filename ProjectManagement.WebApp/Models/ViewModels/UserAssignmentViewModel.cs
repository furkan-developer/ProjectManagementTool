using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class UserAssignmentViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool IsChecked { get; set; }
    }
}