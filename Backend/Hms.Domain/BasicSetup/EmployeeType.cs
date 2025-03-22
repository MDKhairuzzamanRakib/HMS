using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.BasicSetup
{
    public class EmployeeType : BaseDomainEntity
    {
        public int Id { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EmpBasicInfo>? EmpBasicInfo { get; set; }
    }
}
