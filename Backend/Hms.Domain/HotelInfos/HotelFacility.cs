using Hms.Domain.BasicSetup;
using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain.HotelInfos
{
    public class HotelFacility : BaseDomainEntity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public bool? LiftService { get; set; }
        public bool? Breakfast { get; set; }
        public bool? BuffetBreakfast { get; set; }
        public bool? Lunch { get; set; }
        public bool? BuffetLunch { get; set; }
        public bool? Snacks { get; set; }
        public bool? BuffetSnacks { get; set; }
        public bool? Dinner { get; set; }
        public bool? BuffetDinner { get; set; }
        public bool? IndoorGame { get; set; }
        public bool? OutdoorGame { get; set; }
        public bool? SwimmingPool { get; set; }
        public bool? Steamer { get; set; }
        public bool? Gym { get; set; }
        public bool? Shop { get; set; }
        public bool? LaundryService { get; set; }
        public bool? MeetingRoom { get; set; }
        public bool? KidsZone { get; set; }
        public bool? CCTVSurveillance { get; set; }
        public bool? FireSafety { get; set; }
        public bool? FreeWifi { get; set; }
        public bool? Parking { get; set; }
        public bool? PersonalGuide { get; set; }
        public bool? WaitingZone { get; set; }

        public virtual HotelInfo? HotelInfo { get; set; }
    }
}
