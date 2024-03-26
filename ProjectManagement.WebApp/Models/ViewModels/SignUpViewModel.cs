using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.WebApp.Models.ViewModels
{
    public class SignUpViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Gender Gender { get; set; } = Gender.Unknown;
        public DateTime BirthDay { get; set; }
        public string Password { get; set; } = default!;
    }
}