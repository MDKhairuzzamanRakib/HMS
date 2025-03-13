using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public string? CreatedBy { get; set; } = null!;
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
    }
}
