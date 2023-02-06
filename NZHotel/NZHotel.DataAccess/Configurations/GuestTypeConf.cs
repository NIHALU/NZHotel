using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NZHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.DataAccess.Configurations
{
    public class GuestTypeConf : IEntityTypeConfiguration<GuestType>
    {
        public void Configure(EntityTypeBuilder<GuestType> builder)
        {
            builder.Property(x => x.Definiton).HasMaxLength(30).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
        }
    }
}
