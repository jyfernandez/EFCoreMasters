using InventoryAppEFCore.DataLayer.Configurations;
using InventoryAppEFCore.DataLayer.Models.Entities;
using InventoryAppEFCore.DataLayer.Views;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

            modelBuilder.Entity<Client>().HasData(
             new
             {
                ClientId = 1,
                Name = "John Doe"
             }
            );

            modelBuilder.Entity<Order>().HasData(
             new
             {
                 OrderId = 1,
                 DateOrderedUtc = new DateTime(),
                 ClientId = 1,
                 LineItemId = 1,
                 Status = OrderStatus.Complete,
             }
            );
            modelBuilder.Entity<LineItem>().HasData(
             new 
             { 
                 LineItemId = 1, 
                 NumOfProducts = (short) 3, 
                 ProductPrice = 100M, 
                 OrderId = 1,
                 ProductId = 1
             }
            );

            modelBuilder.Entity<Product>().HasData(
              new 
              { 
                  ProductId = 1, 
                  Name = "Bag", 
                  LineItemId = 1,
                  PriceOffer = 1
              },
              new 
              { 
                  ProductId = 2, 
                  Name = "Shoes",
                  LineItemId = 1,
                  PriceOffer = 2
              },
              new 
              { 
                  ProductId = 3,
                  Name = "Shirt",
                  LineItemId = 1,
                  PriceOffer = 3
              }
            );

            modelBuilder.Entity<PriceOffer>().HasData(
              new 
              {
                  PriceOfferId = 1,
                  NewPrice = 100M,
                  PromotinalText = "10% Off",
                  ProductId = 1,
                  Currency = "Php"
              },
              new
              {
                  PriceOfferId = 2,
                  NewPrice = 200M,
                  PromotinalText = "20% Off",
                  ProductId = 2,
                  Currency = "Php"
              },
              new
              {
                  PriceOfferId = 3,
                  NewPrice = 150M,
                  PromotinalText = "30% Off",
                  ProductId = 3,
                  Currency = "Php"
              }
            );
        }

    }
}