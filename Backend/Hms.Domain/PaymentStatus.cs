using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class PaymentStatus : BaseDomainEntity
    {
        public int Id { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? BookingId { get; set; }
        public double? PaidAmmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Remark { get; set; }
        public bool? Status { get; set; }
    }
}
