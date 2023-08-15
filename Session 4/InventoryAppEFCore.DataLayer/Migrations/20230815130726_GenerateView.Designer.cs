﻿// <auto-generated />
using System;
using InventoryAppEFCore.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    [DbContext(typeof(InventoryAppEfCoreContext))]
    [Migration("20230815130726_GenerateView")]
    partial class GenerateView
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.LineItem", b =>
                {
                    b.Property<int>("LineItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineItemId"), 1L, 1);

                    b.Property<short>("NumOfProducts")
                        .HasColumnType("smallint");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LineItemId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrderedUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("LineItemId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.PriceOffer", b =>
                {
                    b.Property<int>("PriceOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceOfferId"), 1L, 1);

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PromotinalText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceOfferId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("PriceOffers");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<DateTime>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LineItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("LineItemId")
                        .IsUnique();

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.ProductSupplier", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<byte>("Order")
                        .HasColumnType("tinyint");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("VoterName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            Description = "Shoppee Supplier",
                            Name = "Shoppee"
                        },
                        new
                        {
                            SupplierId = 2,
                            Description = "Lazada Supplier",
                            Name = "Lazada"
                        },
                        new
                        {
                            SupplierId = 3,
                            Description = "Tiktok Supplier",
                            Name = "Tiktok"
                        },
                        new
                        {
                            SupplierId = 4,
                            Description = "Marketplace Supplier",
                            Name = "Marketplace"
                        },
                        new
                        {
                            SupplierId = 5,
                            Description = "Instagram Supplier",
                            Name = "Instagram"
                        },
                        new
                        {
                            SupplierId = 6,
                            Description = "Carousel Supplier",
                            Name = "Carousel"
                        });
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Views.SupplierView", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToView("SupplierView");
                });

            modelBuilder.Entity("LineItemOrder", b =>
                {
                    b.Property<int>("LineItemsLineItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.HasKey("LineItemsLineItemId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("LineItemOrder");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<string>("TagsTagId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductsProductId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.PriceOffer", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Product", null)
                        .WithOne("Promotion")
                        .HasForeignKey("InventoryAppEFCore.DataLayer.Models.Entities.PriceOffer", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Product", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.LineItem", "LineItems")
                        .WithOne("SelectedProduct")
                        .HasForeignKey("InventoryAppEFCore.DataLayer.Models.Entities.Product", "LineItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Supplier", null)
                        .WithMany("ProductsLink")
                        .HasForeignKey("SupplierId");

                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.ProductSupplier", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Product", "Product")
                        .WithMany("SuppliersLink")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Review", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LineItemOrder", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.LineItem", null)
                        .WithMany()
                        .HasForeignKey("LineItemsLineItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.Models.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.LineItem", b =>
                {
                    b.Navigation("SelectedProduct")
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Product", b =>
                {
                    b.Navigation("Promotion")
                        .IsRequired();

                    b.Navigation("Reviews");

                    b.Navigation("SuppliersLink");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.Models.Entities.Supplier", b =>
                {
                    b.Navigation("ProductsLink");
                });
#pragma warning restore 612, 618
        }
    }
}
