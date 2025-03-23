using Hms.Domain.BasicSetup;
using Hms.Domain.BookingInfos;
using Hms.Domain.Common;
using Hms.Domain.PaymentInfos;
using Hms.Domain.UserManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.EmployeeInfos
{
    public class EmpBasicInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public string? AspNetUserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmergencyContact { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? ZipCode { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }

        public virtual AspNetUsers? AspNetUsers { get; set; }
        public virtual EmployeeType? EmployeeType { get; set; }
        public virtual Country? Country { get; set; }
        public virtual City? City { get; set; }
        public virtual ICollection<EmpJobDetail>? EmpJobDetail { get; set; }
        public virtual ICollection<EmpPersonalInfo>? EmpPersonalInfo { get; set; }
        public virtual ICollection<PaymentStatus>? PaymentStatus { get; set; }
        public virtual ICollection<BookingInfo>? BookingInfoReferBy { get; set; }
        public virtual ICollection<BookingInfo>? BookingInfoDiscountBy { get; set; }
    }
}
