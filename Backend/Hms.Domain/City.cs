using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class City : BaseDomainEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int? CountryId { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
