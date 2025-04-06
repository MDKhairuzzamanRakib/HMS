using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.UserManage
{
    public class UserLogInTracker : BaseDomainEntity
    {
        [Key]
        public string LoginTrackerID { get; set; }
        public int? LoginAttempts { get; set; }
        public TimeOnly? LogInTime { get; set; }
        public TimeOnly? LogOutTime { get; set; }
        public string? LogInSessionIP { get; set; }
        [Column(TypeName = "decimal(18, 10)")] public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(18, 10)")] public decimal? Longitude { get; set; }

        [ForeignKey("UserProfile")]
        public string UserID { get; set; }
    }
}
