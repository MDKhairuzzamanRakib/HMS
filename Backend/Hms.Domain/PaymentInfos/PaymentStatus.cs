using Hms.Domain.BasicSetup;
using Hms.Domain.BookingInfos;
using Hms.Domain.Common;
using Hms.Domain.EmployeeInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.PaymentInfos
{
    public class PaymentStatus : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? BookingId { get; set; }
        public double? PaidAmmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool? Confirmation { get; set; }
        public int? ConfirmedBy { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }

        public virtual PaymentType? PaymentType { get; set; }
        public virtual BookingInfo? BookingInfo { get; set; }
        public virtual EmpBasicInfo? EmpBasicInfo { get; set; }
    }
}
