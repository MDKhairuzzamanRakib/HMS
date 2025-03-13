using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.DTOs.User
{
    public class PasswordChangeDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }


        public string ConfirmPassword { get; set; }
        public string UserId { get; set; }
    }
}

