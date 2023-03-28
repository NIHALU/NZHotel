using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace NZHotel.UI.Areas.Member.Models
{
    public class BookingRoomModel
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }
        public int NumberofDays => (FinishingDate - StartingDate).Days;
        public int EarlyBookingDay => (StartingDate - DateTime.Now).Days;

        public int ReservationOptionId { get; set; }
        public SelectList ReservationOptions { get; set; }
    }
}
