using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RoleName { get; set; }
        public bool? CanEditProfile { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
        public string? InActiveBy { get; set; }
        public DateTime? InActiveDate { get; set; }
    }
}