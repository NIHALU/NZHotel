using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities.Employee
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int  IdentityNumber { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
