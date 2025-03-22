using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using Hms.Domain.GuestInfos;
using Hms.Domain.PaymentInfos;
using Hms.Domain.RoomInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.BookingInfos
{
    public class BookingInfo : BaseDomainEntity
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomPricingId { get; set; }
        public int? ReferedById { get; set; }
        public double? SpecialDiscount { get; set; }
        public int? DiscountById { get; set; }
        public string? DiscountRemark { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? SpecialRequest { get; set; }
        public bool? Confirmation { get; set; }
        public int? ConfirmedBy { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PaymentStatus>? PaymentStatus { get; set; }
        public virtual GuestInfo? GuestInfo { get; set; }
        public virtual RoomPricing? RoomPricing { get; set; }
        public virtual EmpBasicInfo? ReferedBy { get; set; }
        public virtual EmpBasicInfo? DiscountBy { get; set; }
    }
}
