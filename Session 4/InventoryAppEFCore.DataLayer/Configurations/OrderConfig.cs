using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.Configurations
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var utcConverter = new ValueConverter<DateTime, DateTime>(
               toDb => toDb,
               fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.DateOrderedUtc)
            .HasConversion(utcConverter);
        }
    }
}
