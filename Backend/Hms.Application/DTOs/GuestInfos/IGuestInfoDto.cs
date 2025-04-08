using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.DTOs.GuestInfos
{
    public interface IGuestInfoDto
    {
        public int Id { get; set; }
        public string? AspNetUserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoUrl { get; set; }
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
    }
}
