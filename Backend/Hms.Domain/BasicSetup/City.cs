using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.GuestInfos;
using Hms.Domain.HotelInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.BasicSetup
{
    public class City : BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<EmpBasicInfo>? EmpBasicInfo { get; set; }
        public virtual ICollection<GuestInfo>? GuestInfo { get; set; }
        public virtual ICollection<HotelInfo>? HotelInfo { get; set; }
    }
}
