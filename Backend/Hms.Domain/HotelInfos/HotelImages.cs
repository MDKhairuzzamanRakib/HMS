using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.HotelInfos
{
    public class HotelImages : BaseDomainEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int? PhotoUrl { get; set; }
        public bool IsDefault { get; set; }

        public virtual HotelInfo? HotelInfo { get; set; }
    }
}
