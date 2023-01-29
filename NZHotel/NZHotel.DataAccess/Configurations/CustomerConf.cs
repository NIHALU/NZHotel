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
    public class CustomerConf : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.ContactName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContactSurname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContactEmail).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ContactPhone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Adress).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.TurkishIDNo).HasMaxLength(11).IsRequired();
            builder.Property(x => x.PassportNo).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(20);
            builder.HasMany(x=>x.Reservations).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId);
        }
    }
}
