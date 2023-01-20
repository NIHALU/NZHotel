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
        public Reservation()
        {
            List<GuestDetail> GuestDetails = new List<GuestDetail>();
        }
        public int NumberofDays { get; set; }
        public Status Status {get; set; }
        public ReservationOptions ReservationOptions { get; set; }
        public int RoomNo { get; set; }
        public PaymentStatus  PaymentStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public List<GuestDetail> GuestDetails { get; set; }
        public List<GuestReservation> GuestReservations { get; set; }

        //Navigational Prop Begins
        public int RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }
       
        //public int PaymentId { get; set; }
        //public Payment Payment { get; set; }
        //public List<ExtraPayment> ExtraPayments { get; set; }
    }
}
