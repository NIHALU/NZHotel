using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ReservationCreateDto:IDto
    {      
        public int NumberofDays { get; set; }
        public bool IsActive {get; set; }
        public string ReservationOptions { get; set; }
        public int RoomNo { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime FinisingDate { get; set; }
    }
}
