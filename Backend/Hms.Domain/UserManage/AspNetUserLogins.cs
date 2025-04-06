using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.UserManage
{
    public class AspNetUserLogins
    {
        //[Key]
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("AspNetUserLogin_UserId")]
        //public virtual AspNetUsers User { get; set; }
    }
}
