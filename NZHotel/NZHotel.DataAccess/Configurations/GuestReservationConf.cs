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
    public class GuestReservationConf : IEntityTypeConfiguration<GuestReservation>
    {
        public void Configure(EntityTypeBuilder<GuestReservation> builder)
        {
            builder.HasIndex(x => new
            {
                x.GuestId,
                x.ReservationId
            }).IsUnique(true);

            builder.HasOne(x => x.Guest).WithMany(x => x.GuestReservations).HasForeignKey(x => x.GuestId);
            builder.HasOne(x => x.Reservation).WithMany(x => x.GuestReservations).HasForeignKey(x => x.ReservationId);
        }
    }
}
