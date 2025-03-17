using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class EmpJobDetails : BaseDomainEntity
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
        public int? FirstDepartmentId { get; set; }
        public int? FirstSectionId { get; set; }
        public int? FirstDesignationId { get; set; }
        public bool? ServiceStatus { get; set; }
        public string? Remark { get; set; }
    }
}
