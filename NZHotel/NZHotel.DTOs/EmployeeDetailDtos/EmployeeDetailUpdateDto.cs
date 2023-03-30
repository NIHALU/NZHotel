using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class EmployeeDetailUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public decimal? DailyWage { get; set; }
        public decimal? Salary { get; set; }
        public decimal? OvertimeWage { get; set; }
        public int? DailyWorkingHour { get; set; }
        public int? MonthlyWorkingDay { get; set; }
        public int ShiftTypeId { get; set; }
        public int? OvertimeNumber { get; set; }
    }
}
