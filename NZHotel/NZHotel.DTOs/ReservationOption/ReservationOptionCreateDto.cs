using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ReservationOptionCreateDto:IDto
    {
        public string Definition { get; set; }

    }
}
