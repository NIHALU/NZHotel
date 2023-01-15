using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class Reservation: BaseEntity
    {
        public int NumberofDays { get; set; }
        public ReservationOptions ReservationOptions { get; set; }
        public DateTime CreateDate { get; set; }
        //public DateTime StartingDate { get; set; }
        //public DateTime FinisingDate { get; set; }

        //Navigational Prop Begins
        public List<Room> Rooms { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment{ get; set; }
        public List<ExtraPayment> ExtraPayments { get; set; }
    }
}
