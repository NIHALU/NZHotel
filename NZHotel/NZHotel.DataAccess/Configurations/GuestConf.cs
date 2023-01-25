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
    public class GuestConf : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(30).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Address).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.IdentityNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.PassportNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Nationality).HasMaxLength(20);
            builder.Property(x => x.CountryName).HasMaxLength(20);
            builder.Property(x => x.BirthDay).IsRequired();

        
        }
    }
}
