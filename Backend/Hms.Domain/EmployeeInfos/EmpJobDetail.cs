using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.HotelInfos;
using Hms.Domain.OrganogramSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.EmployeeInfos
{
    public class EmpJobDetail : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? HotelId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public int? DesignationId { get; set; }
        public double? Salary { get; set; }
        public DateOnly? JoiningDate { get; set; }
        public DateOnly? ConfirmationDate { get; set; }
        public int? FirstHotelId { get; set; }
        public int? FirstDepartmentId { get; set; }
        public int? FirstSectionId { get; set; }
        public int? FirstDesignationId { get; set; }
        public string? Remark { get; set; }
        public bool? ServiceStatus { get; set; }

        public virtual EmpBasicInfo? EmpBasicInfo { get; set; }
        public virtual HotelInfo? HotelInfo { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Designation? Designation { get; set; }
        public virtual HotelInfo? FirstHotelInfo { get; set; }
        public virtual Department? FirstDepartment { get; set; }
        public virtual Section? FirstSection { get; set; }
        public virtual Designation? FirstDesignation { get; set; }
    }
}
