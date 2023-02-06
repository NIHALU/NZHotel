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
            builder.Property(x => x.MaxAdults).IsRequired();
            builder.Property(x => x.MaxChildren).IsRequired();
            builder.Property(x => x.BedInfo).HasMaxLength(40).IsRequired();
            builder.Property(x => x.RoomName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.RoomDetail).WithOne(x => x.Room).HasForeignKey<RoomDetail>(x => x.RoomId);
            builder.HasOne(x => x.RoomType).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomTypeId);
            builder.HasOne(x => x.CleaningStatus).WithMany(x => x.Rooms).HasForeignKey(x => x.CleaningStatusId);
        }
    }
}
