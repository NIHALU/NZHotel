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
    public class ReservationConf : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.TotalAmount).HasPrecision(18, 3);
            builder.HasOne(x => x.Room).WithMany(x => x.Reservations).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.ReservationOption).WithMany(x => x.Reservations).HasForeignKey(x => x.ReservationOptionId);
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");

        }
    }
}
