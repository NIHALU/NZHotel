using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Gender:BaseEntity
    {
        public string Definition { get; set; }

        public List<Guest> Guests { get; set; }

        public List<Employees.Employee> Employees { get; set; }
    }
}
