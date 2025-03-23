using Hms.Domain.BasicSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.UserManage
{
    public class AspNetUserRoles
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }

        public virtual AspNetUsers? AspNetUsers { get; set; }
        public virtual AspNetRoles? AspNetRoles { get; set; }
    }
}
