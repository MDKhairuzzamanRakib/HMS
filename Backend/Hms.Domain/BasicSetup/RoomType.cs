using Hms.Domain.Common;
using Hms.Domain.RoomInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.BasicSetup
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

        public virtual ICollection<RoomInfo>? RoomInfo { get; set; }
    }
}
