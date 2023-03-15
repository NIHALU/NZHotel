using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Image:BaseEntity
    {
        public string ImageName { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
    }
}
