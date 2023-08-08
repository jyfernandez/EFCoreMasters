using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.Configurations
{
    internal class LineItemConfig : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(l => l.LineItemId);

            builder.HasOne(l => l.SelectedProduct)
            .WithOne(l => l.LineItems)
            .HasForeignKey<Product>(l => l.LineItemId);

            builder.HasMany(l => l.Orders)
            .WithMany(l => l.LineItems);
        }
    }
}
