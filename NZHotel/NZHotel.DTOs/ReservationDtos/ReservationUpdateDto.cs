using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ReservationUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public int NumberofDays { get; set; }
        public int NumberofGuests { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public int ReservationOptionId { get; set; }
    }
}
