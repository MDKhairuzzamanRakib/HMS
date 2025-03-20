using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class BookingInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomPricingId { get; set; }
        public int? CouponId { get; set; }
        public int? ReferedBy { get; set; }
        public double? SpecialDiscount { get; set; }
        public int? DiscountBy { get; set; }
        public string? DiscountRemark { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? SpecialRequest { get; set; }
        public bool? Confirmation { get; set; }
        public int? ConfirmedBy { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }
    }
}
