using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Reservation : BaseEntity
    {
       
        public int NumberofDays { get; set; }
        public int NumberofGuests { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public bool IsActive { get; set; } = true;
        public List<GuestReservation> GuestReservations { get; set; }

        //Navigational Prop Begins
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ReservationOptionId { get; set; }
        public ReservationOption ReservationOption { get; set; }

        public bool InStart(DateTime enterance, DateTime exit )//False
        {
            return (StartingDate < enterance) && (exit <= StartingDate);
        }
        public bool InFinish(DateTime enterance, DateTime exit)//False 
        {
            return (FinisingDate <= enterance) && (exit < FinisingDate);
        }


    }
}
