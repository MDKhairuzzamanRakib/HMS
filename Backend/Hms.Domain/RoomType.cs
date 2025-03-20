using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class RoomType : BaseDomainEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public double? PriceStart { get; set; }
        public double? PriceEnd { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
