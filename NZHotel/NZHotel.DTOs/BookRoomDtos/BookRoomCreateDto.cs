using NZHotel.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.DTOs
{
    public class BookRoomCreateDto:IDto
    {
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }
        public int ReservationOptionId { get; set; }
    }
}
