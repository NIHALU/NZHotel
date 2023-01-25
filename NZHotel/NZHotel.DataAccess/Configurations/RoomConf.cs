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
    public class RoomConf : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
          builder.Property(x => x.Capacity).IsRequired();

          builder.HasOne(x=>x.RoomDetail).WithOne(x=>x.Room).HasForeignKey<RoomDetail>(x=>x.RoomId);
          builder.HasOne(x => x.RoomType).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomTypeId);
           
          //builder.HasMany(x => x.Reservations).WithOne(x => x.Room).HasForeignKey(x=> x.RoomId);
        }
    }
}
