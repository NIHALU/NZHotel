using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class GuestReservationCreateDto:IDto
    {
        public int GuestId { get; set; }
        public int ReservationId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public string ReservationCode { get; set; }
    }
}
