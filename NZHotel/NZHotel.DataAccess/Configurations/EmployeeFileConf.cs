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
    public class EmployeeFileConf : IEntityTypeConfiguration<EmployeeFile>
    {
        public void Configure(EntityTypeBuilder<EmployeeFile> builder)
        {
            builder.Property(x => x.OffDay).IsRequired();
        }
    }
}
