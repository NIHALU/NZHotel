using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities.Employee
{
    public class EmployeeDetails:BaseEntity
    {
        public string Title { get; set; }
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public ShiftType ShiftType { get; set; }
        public string Overtime { get; set; }

        //Navigational Prop Begins
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
