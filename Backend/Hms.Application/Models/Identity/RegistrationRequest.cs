using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }

        //[Required]
        public string LastName { get; set; }

        //[Required]
        //[EmailAddress]
        public string? Email { get; set; }

        [Required]
        //[MinLength(6)]
        public string UserName { get; set; }

        //[Required]
        public string? PhoneNumber { get; set; }

        public DateOnly? DateOfBirth { get; set; }
        public int? GenderId { get; set; }


        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool CanEditProfile { get; set; }
    }
}
