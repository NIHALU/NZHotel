using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class RoomDetails: BaseEntity
    {
        public int FloorInfo { get; set; }
        public bool HasWifi { get; set; }
        public bool HasMinibar { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasSeaView { get; set; }
        public bool HasAC { get; set; }
        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public bool HasLivingRoom { get; set; }

        //Navigational Prop Begins
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
