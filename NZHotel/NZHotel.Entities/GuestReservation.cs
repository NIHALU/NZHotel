using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class GuestReservation:BaseEntity
    {
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public DateTime? CheckInTime { get; set;}
        public DateTime? CheckOutTime { get; set;}
    }
}
