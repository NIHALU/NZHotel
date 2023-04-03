using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities.Employees
{
    public class Shift:BaseEntity
    {
        public string Morning { get; set; } 
        public string Noon { get; set; }
        public string Evening { get; set; }

        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
    }
}
