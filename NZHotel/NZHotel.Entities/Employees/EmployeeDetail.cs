using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities.Employee
{
    public class EmployeeDetail:BaseEntity
    {
        public string Title { get; set; }
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public decimal? DailyWage { get; set; }
        public decimal? Salary { get; set; }
        public decimal? OvertimeWage { get; set; }
        public int DailyWorkingHour { get; set; }
        public int MonthlyWorkingDay{ get; set; }
        public ShiftType ShiftType { get; set; }
        public string OvertimeNumber { get; set; }

        //Navigational Prop Begins
        public int EmployeeId { get; set; }
        public Employees.Employee Employee { get; set; }
    }
}
