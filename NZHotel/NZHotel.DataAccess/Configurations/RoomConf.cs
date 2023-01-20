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
          builder.HasOne(x=>x.RoomDetail).WithOne(x=>x.Room).HasForeignKey<RoomDetail>(x=>x.RoomId);
          builder.HasOne(x => x.RoomType).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomTypeId);
          builder.Property(x => x.Info).HasDefaultValueSql("Check In Time:02:00 pm & Check Out Time:10:00 am");
          //builder.HasMany(x => x.Reservations).WithOne(x => x.Room).HasForeignKey(x=> x.RoomId);
        }
    }
}
