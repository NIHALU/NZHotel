using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(x => x.IdentityNumber).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(40).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");



            builder.HasOne(x => x.EmployeeFile).WithOne(x => x.Employee).HasForeignKey<EmployeeFile>(x => x.EmployeeId);
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId);

            builder.HasOne(x => x.Gender).WithMany(x => x.Employees).HasForeignKey(x => x.GenderId);
            builder.HasOne(x => x.Shift).WithOne(x => x.Employee).HasForeignKey<Shift>(x => x.EmployeeId);
        }
    }
}
