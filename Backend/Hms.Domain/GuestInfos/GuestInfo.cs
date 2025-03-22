using Hms.Domain.BasicSetup;
using Hms.Domain.BookingInfos;
using Hms.Domain.Common;
using Hms.Domain.RoomInfos;
using Hms.Domain.UserManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.GuestInfos
{
    public class GuestInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public string? AspNetUserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? BloodGroupId { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmergencyContact { get; set; }
        public int? ReligionId { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? NID { get; set; }
        public string? SmartNID { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Remark { get; set; }
        public bool Status { get; set; }

        public virtual AspNetUsers? AspNetUsers { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public virtual BloodGroup? BloodGroup { get; set; }
        public virtual Country? Country { get; set; }
        public virtual City? City { get; set; }
        public virtual Religion? Religion { get; set; }
        public virtual ICollection<BookingInfo>? BookingInfo { get; set; }
    }
}
