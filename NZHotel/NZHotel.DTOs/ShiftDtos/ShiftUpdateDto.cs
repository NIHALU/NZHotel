using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class ShiftUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Evening { get; set; }
        public string Regular { get; set; }
        public int EmployeeId { get; set; }
      
    }
}
