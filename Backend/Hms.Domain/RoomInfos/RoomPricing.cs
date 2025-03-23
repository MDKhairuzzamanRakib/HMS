using Hms.Domain.BasicSetup;
using Hms.Domain.BookingInfos;
using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.RoomInfos
{
    public class RoomPricing : BaseDomainEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int RateTypeId { get; set; }
        public double? RegularPrice { get; set; }
        public double? OfferPrice { get; set; }
        public double? Discount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }

        public virtual RoomInfo? RoomInfo { get; set; }
        public virtual RateType? RateType { get; set; }
        public virtual ICollection<BookingInfo>? BookingInfo { get; set; }
    }
}
