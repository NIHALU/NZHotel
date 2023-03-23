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
    public class ImageConf : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.ImageName).IsRequired();
            builder.HasOne(x => x.Room).WithMany(x => x.Images).HasForeignKey(x => x.RoomId);
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
        }
    }
}
