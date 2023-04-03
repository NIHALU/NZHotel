using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Entities.Employees;

namespace NZHotel.Entities
{
    public class WorkingType : BaseEntity
    {
        public string Definition { get; set; }
        public List<EmployeeFile> EmployeeFiles { get; set; }
    }
}
