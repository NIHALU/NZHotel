using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZHotel.Entities.Employee;

namespace NZHotel.DataAccess.Configurations
{
    public class EmployeeDetailConf : IEntityTypeConfiguration<EmployeeDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeDetail> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(10).IsRequired();
            builder.Property(x => x.HourlyWage).HasColumnType("decimal(4,2)");
            builder.Property(x => x.MonthlyWage).HasColumnType("decimal(8,2)");
            builder.Property(x => x.DailyWage).HasColumnType("decimal(8,2)");
            builder.Property(x => x.Salary).HasColumnType("decimal(8,2)");
            builder.Property(x => x.OvertimeWage).HasColumnType("decimal(8,2)");
            builder.Property(x => x.ShiftType).IsRequired();
        }
    }
}
