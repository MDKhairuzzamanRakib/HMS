using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.HotelInfos;
using Hms.Domain.PaymentInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.RoomInfos
{
    public class RoomInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? RoomTypeId { get; set; }
        public int? Floor { get; set; }
        public int? Adult { get; set; }
        public int? Child { get; set; }
        public string? RoomNumber { get; set; }
        public string? Description { get; set; }
        public bool? RoomStatus { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<RoomFacility>? RoomFacility { get; set; }
        public virtual HotelInfo? HotelInfo { get; set; }
        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<RoomPricing>? RoomPricing { get; set; }
    }
}
