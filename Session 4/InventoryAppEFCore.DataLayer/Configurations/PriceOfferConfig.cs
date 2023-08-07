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
    internal class PriceOfferConfig : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> builder)
        {
            builder.HasKey(p => p.PriceOfferId);
        }
    }
}
