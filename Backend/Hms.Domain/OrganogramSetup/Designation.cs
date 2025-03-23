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
    public class Designation : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public int? DesignationSetupId { get; set; }
        public string? Code { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EmpJobDetail>? EmpJobDetail { get; set; }
        public virtual ICollection<EmpJobDetail>? FirstEmpJobDetail { get; set; }
        public virtual HotelInfo? HotelInfo { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Section? Section { get; set; }
        public virtual DesignationSetup? DesignationSetup { get; set; }
    }
}
