using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities.Employees
{
    public class EmployeeFile:BaseEntity
    {
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public decimal? DailyWage { get; set; }
        public decimal? Salary { get; set; }
        public decimal? OvertimeWage { get; set; }
        public int? DailyWorkingHour { get; set; }
        public int? MonthlyWorkingDay { get; set; }

        public int? OvertimeNumber { get; set; }
        public string OffDay { get; set; }


        //Navigational Prop Begins

        public int WorkingTypeId { get; set; }
        public WorkingType WorkingType { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
