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
    public class GuestInfoConf : IEntityTypeConfiguration<GuestInfo>
    {
        public void Configure(EntityTypeBuilder<GuestInfo> builder)
        {
            builder.Property(x =>x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Reservation).WithMany(x => x.GuestInformation).HasForeignKey(x => x.ReservationId);
            builder.HasOne(x => x.GuestType).WithMany(x => x.GuestInformation).HasForeignKey(x => x.GuestTypeId);
        }
    }
}
