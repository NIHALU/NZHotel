using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class EmployeeFileListDto:IDto
    {
        public int Id { get; set; }
     
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public decimal? DailyWage { get; set; }
        public decimal Salary { get; set; }
        public decimal? OvertimeWage { get; set; }
        public int? DailyWorkingHour { get; set; }
        public int? MonthlyWorkingDay { get; set; }
       
        public int? OvertimeNumber { get; set; }
      
        public string OffDay { get; set; }

        public EmployeeListDto Employee { get; set; }
        public int WorkingTypeId { get; set; }
        public WorkingTypeListDto WorkingType { get; set; }

        public int EmployeeId { get; set; }

        public decimal SalaryWithOverTime { get; set; }
        public decimal CalculateOverTimeSalary()
        {
            return (decimal)(Salary + (OvertimeWage * OvertimeNumber));
        }
    }
}
