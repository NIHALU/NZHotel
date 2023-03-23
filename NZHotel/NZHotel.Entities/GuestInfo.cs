using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class GuestInfo:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age { get; set; }

        //navigational props begin

        public GuestType  GuestType { get; set; }
        public int GuestTypeId { get; set; }

        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }



    }
}
