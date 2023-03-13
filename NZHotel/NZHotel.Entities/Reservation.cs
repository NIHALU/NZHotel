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
        public int NumberofGuests { get; set; }
        public int NumberofDays => (FinishingDate - StartingDate).Days;

        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public bool Active { get; set; } = true;

        //Navigational Prop Begins
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ReservationOptionId { get; set; }
        public ReservationOption ReservationOption { get; set; }

        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public int ReservationTypeId { get; set; }
        public ReservationType ReservationType { get; set; }
        public List<GuestReservation> GuestReservations { get; set; }


        public bool InStart(DateTime enterance, DateTime exit)//False
        {
            return (StartingDate.Date < enterance.Date) && (exit.Date <= StartingDate.Date);
        }
        public bool InFinish(DateTime enterance, DateTime exit)//False 
        {
            return (FinishingDate.Date <= enterance.Date) && (exit.Date < FinishingDate.Date);
        }






    }
}
