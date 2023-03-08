using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZHotel.Entities.Employee;
using NZHotel.Entities.Employees;

namespace NZHotel.DataAccess.Configurations
{
    public class EmployeeConf : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Address).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.IdentityNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(10).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Active).IsRequired().HasDefaultValueSql("1");


            builder.HasOne(x => x.EmployeeDetail).WithOne(x => x.Employee).HasForeignKey<EmployeeDetail>(x => x.EmployeeId);
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId);

            builder.HasOne(x => x.Gender).WithMany(x => x.Employees).HasForeignKey(x => x.GenderId);
        }
    }
}
