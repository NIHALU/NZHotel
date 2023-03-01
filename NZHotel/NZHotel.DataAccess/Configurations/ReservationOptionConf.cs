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
    public class ReservationOptionConf : IEntityTypeConfiguration<ReservationOption>
    {
        public void Configure(EntityTypeBuilder<ReservationOption> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(30).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
           


        }
    }
}
