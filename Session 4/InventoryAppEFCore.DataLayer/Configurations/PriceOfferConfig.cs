using InventoryAppEFCore.DataLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.Configurations
{
    internal class PriceOfferConfig : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> builder)
        {
            builder.HasKey(p => p.PriceOfferId);
            
            builder
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("getutcdate()");

            builder
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false);
            builder
                 .Property(c => c.NewPriceText)
                .HasComputedColumnSql("[Currency] + ',' + CAST([NewPrice] AS NVARCHAR(255))", stored: true);
            builder
                .HasQueryFilter(x => !x.IsDeleted);

        }
    }
}
