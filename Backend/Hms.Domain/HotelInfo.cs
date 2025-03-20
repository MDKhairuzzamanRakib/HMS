using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class HotelInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? Motto { get; set; }
        public int? Country { get; set; }
        public int? City { get; set; }
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
    }
}
