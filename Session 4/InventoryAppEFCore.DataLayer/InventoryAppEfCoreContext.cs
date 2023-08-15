using InventoryAppEFCore.DataLayer.Configurations;
using InventoryAppEFCore.DataLayer.Models.Entities;
using InventoryAppEFCore.DataLayer.Views;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SupplierView> SupplierView { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO Fluent API

            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new PriceOfferConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new LineItemConfig());
            modelBuilder.ApplyConfiguration(new ProductSupplierConfig());

            //Create View

            modelBuilder.Entity<SupplierView>().ToView("SupplierView").HasKey(s => s.SupplierId);

            //Seed Data to Supplier
            modelBuilder.Entity<Supplier>().HasData(
               new { SupplierId = 1, Name = "Shoppee", Description = "Shoppee Supplier" },
               new { SupplierId = 2, Name = "Lazada", Description = "Lazada Supplier" },
               new { SupplierId = 3, Name = "Tiktok", Description = "Tiktok Supplier" },
               new { SupplierId = 4, Name = "Marketplace", Description = "Marketplace Supplier" },
               new { SupplierId = 5, Name = "Instagram", Description = "Instagram Supplier" },
               new { SupplierId = 6, Name = "Carousel", Description = "Carousel Supplier" }
            );

        }

    }
}