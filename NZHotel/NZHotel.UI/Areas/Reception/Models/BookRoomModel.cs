using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Common.Enums;

namespace NZHotel.UI
{
    public class BookRoomModel
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }
        public int NumberofDays => (FinisingDate - StartingDate).Days;
        public int EarlyBookingDay => (StartingDate - DateTime.Now).Days*(-1);

        public int ReservationOptionId { get; set; }
        public SelectList ReservationOptions { get; set; }


        
      
    }
}
