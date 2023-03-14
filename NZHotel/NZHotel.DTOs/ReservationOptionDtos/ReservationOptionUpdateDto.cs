using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ReservationOptionUpdateDto: IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
