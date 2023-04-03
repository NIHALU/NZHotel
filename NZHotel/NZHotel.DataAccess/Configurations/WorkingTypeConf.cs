using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZHotel.Entities;

namespace NZHotel.DataAccess.Configurations
{
    public class WorkingTypeConf : IEntityTypeConfiguration<WorkingType>
    {
        public void Configure(EntityTypeBuilder<WorkingType> builder)
        {
            builder.Property(x => x.Definition).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.EmployeeFiles).WithOne(x => x.WorkingType).HasForeignKey(x => x.WorkingTypeId);

           
        }
    }
}
