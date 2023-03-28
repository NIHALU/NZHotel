using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class GuestReservationUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int ReservationId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}
