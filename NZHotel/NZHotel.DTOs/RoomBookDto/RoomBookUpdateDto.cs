using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class RoomBookUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? FinisingDate { get; set; }
        public int AdultNumber { get; set; }
        public int ChildNumber { get; set; }
        public int InfantNumber { get; set; }
    }
}
