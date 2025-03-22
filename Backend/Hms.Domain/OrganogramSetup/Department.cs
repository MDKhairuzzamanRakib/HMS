using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.HotelInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.OrganogramSetup
{
    public class Department : BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public int? HotelId { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EmpJobDetail>? EmpJobDetail { get; set; }
        public virtual HotelInfo? HotelInfos { get; set; }
        public virtual ICollection<Section>? Section { get; set; }
        public virtual ICollection<Designation>? Designation { get; set; }
    }
}
