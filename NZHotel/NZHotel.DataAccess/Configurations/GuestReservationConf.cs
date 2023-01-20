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
                x.ReservationId,
                x.GuestId
            }).IsUnique(true);
        }
    }
}
