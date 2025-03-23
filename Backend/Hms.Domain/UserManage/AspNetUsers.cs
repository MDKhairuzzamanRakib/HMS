using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.GuestInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.UserManage
{
    public class AspNetUsers : BaseDomainEntity
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; } = true;
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string? PasswordHash { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; } = true;
        public int AccessFailedCount { get; set; } = 0;
        public int? UserTypeId { get; set; }
        public bool Status { get; set; }
        public bool? CanEditProfile { get; set; }

        public virtual ICollection<EmpBasicInfo>? EmpBasicInfo { get; set; }
        public virtual ICollection<GuestInfo>? GuestInfo { get; set; }
        public virtual UserType? UserType { get; set; }
        public virtual ICollection<AspNetUserRoles>? AspNetUserRoles { get; set; }
    }
}

