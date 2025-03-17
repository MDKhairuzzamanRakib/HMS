using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class RoomInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public int? Floor { get; set; }
        public string? RoomNumber { get; set; }
        public string? Description { get; set; }
        public bool? RoomStatus { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
