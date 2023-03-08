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
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.IsNoTurkishCitizen).HasDefaultValueSql("0");
            builder.Property(x => x.Address).HasColumnType("ntext");
            builder.Property(x => x.IdentityNumber).HasMaxLength(11);
            builder.Property(x => x.PassportNumber).HasMaxLength(11);
            builder.Property(x => x.Nationality).HasMaxLength(20);
            builder.Property(x => x.CountryName).HasMaxLength(20);
            builder.Property(x => x.BirthDay).IsRequired();
            builder.Property(x => x.IsNoTurkishCitizen).IsRequired(true);

            builder.HasOne(x => x.GuestType).WithMany(x => x.Guests).HasForeignKey(x => x.GuestTypeId);
            builder.HasOne(x => x.Gender).WithMany(x => x.Guests).HasForeignKey(x => x.GenderId);


        }
    }
}
