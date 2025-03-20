using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class EmpBasicInfo: BaseDomainEntity
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
        public int? Country { get; set; }
        public int? City { get; set; }
        public int? ZipCode { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
    }
}
