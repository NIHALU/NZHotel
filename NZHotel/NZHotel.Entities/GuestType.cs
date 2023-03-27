using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class GuestType:BaseEntity
    {
        public string Definition { get; set; }

        public List<Guest> Guests { get; set; }

        public List<GuestInfo> GuestInformation { get; set; }
    }
}
