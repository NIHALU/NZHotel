using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class RoomCreateDto:IDto
    {
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomNo { get; set; }
        public string Info { get; set; }
        public int RoomTypeId { get; set; }
        public string BedInfo { get; set; }
        public string RoomName { get; set; }
        public int CleaningStatusId { get; set; }
        public int RoomStatusId { get; set; }
    }
}
