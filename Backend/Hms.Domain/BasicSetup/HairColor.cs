using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.BasicSetup
{
    public class HairColor : BaseDomainEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EmpPersonalInfo>? EmpPersonalInfo { get; set; }
    }
}
