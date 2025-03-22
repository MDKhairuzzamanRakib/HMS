using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.DTOs.UserManage.AspNetRoles
{
    public class CreateRoleDto : IRoleDto
    {
        public string RoleName { get; set; } = null!;

    }
}
