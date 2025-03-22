using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.OrganogramSetup;
using Hms.Domain.PaymentInfos;
using Hms.Domain.RoomInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.HotelInfos
{
    public class HotelInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? Motto { get; set; }
        public int? CategoryId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? ZipCode { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? TollFree { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public TimeOnly? CheckInTime { get; set; }
        public TimeOnly? CheckOutTime { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<EmpJobDetail>? EmpJobDetail { get; set; }
        public virtual CategoryType? CategoryType { get; set; }
        public virtual Country? Country { get; set; }
        public virtual City? City { get; set; }
        public virtual ICollection<HotelFacility>? HotelFacility { get; set; }
        public virtual ICollection<Department>? Department { get; set; }
        public virtual ICollection<Section>? Section { get; set; }
        public virtual ICollection<Designation>? Designation { get; set; }
        public virtual ICollection<RoomInfo>? RoomInfo { get; set; }
    }
}
