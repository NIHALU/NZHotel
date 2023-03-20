using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI
{
    public class BookRoomModel
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }

        public int ReservationOptionId { get; set; }
        public SelectList ReservationOptions { get; set; }
    }
}
