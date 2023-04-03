using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.Common.Enums;

namespace NZHotel.UI.Areas.Management.Models
{
    public class EmployeeFileCreateModel
    {
        public decimal? HourlyWage { get; set; }
        public decimal? MonthlyWage { get; set; }
        public decimal? DailyWage { get; set; }
        public decimal? Salary { get; set; }
        public decimal? OvertimeWage { get; set; }
        public int DailyWorkingHour { get; set; }
        public int? MonthlyWorkingDay { get; set; }

        public int? OvertimeNumber { get; set; }

        public string OffDay { get; set; }
        public int WorkingTypeId { get; set; }  
        public int EmployeeId { get; set; } 

        public SelectList WorkingTypes { get; set; }    
        public SelectList Employees { get; set; }


        public decimal CalculateIrregularSalary()
        {
            return (decimal)(HourlyWage * DailyWorkingHour * MonthlyWorkingDay);
        }

        public decimal CalculateRegularSalary()
        {
            return (decimal)MonthlyWage;
        }

    }
}
