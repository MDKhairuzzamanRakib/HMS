using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class RoomFacility : BaseDomainEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public bool? Ac { get; set; }
        public bool? FreeWifi { get; set; }
        public bool? Tv { get; set; }
        public bool? Telephone { get; set; }
        public bool? Wardrobe { get; set; }
        public bool? DeskAndChair { get; set; }
        public bool? Sofa { get; set; }
        public bool? Fridge { get; set; }
        public bool? TeaMaker { get; set; }
        public bool? Bathtub { get; set; }
        public bool? RoomService { get; set; }
        public bool? DailyHousekeeping { get; set; }
        public bool? LaundryService { get; set; }
        public bool? Balcony { get; set; }
        public bool? ElectronicKey { get; set; }
        public bool? NumberOfBed { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
