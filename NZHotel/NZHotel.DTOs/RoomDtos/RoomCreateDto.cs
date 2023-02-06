using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.RoomDtos
{
    public class RoomCreateDto:IDto
    {
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        //public int Capacity { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomNo { get; set; }
        public string Info { get; set; }
        public int RoomTypeId { get; set; }
    }
}
