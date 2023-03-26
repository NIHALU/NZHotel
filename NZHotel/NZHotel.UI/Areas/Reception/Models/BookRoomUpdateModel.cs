using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Reception.Models
{
    public class BookRoomUpdateModel
    {
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinishingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }

        public decimal OldAmount { get; set; }
        public int NumberofDays => (FinishingDate - StartingDate).Days;
        public int EarlyBookingDay => (StartingDate - DateTime.Now).Days;
        public int ReservationOptionId { get; set; }
        public SelectList ReservationOptions { get; set; }
    }
}
