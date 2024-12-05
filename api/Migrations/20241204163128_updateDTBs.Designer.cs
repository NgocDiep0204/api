﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241204163128_updateDTBs")]
    partial class updateDTBs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("api.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("api.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentBrandId")
                        .HasColumnType("int");

                    b.HasKey("BrandId");

                    b.HasIndex("ParentBrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("api.Models.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderTypeId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrderId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("api.Models.OrderDetail", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("api.Models.OrderType", b =>
                {
                    b.Property<string>("OrderTypeId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OrderTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrderTypeId");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Battery")
                        .HasColumnType("longtext");

                    b.Property<string>("BrandId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("BrandId1")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<string>("HardWare")
                        .HasColumnType("longtext");

                    b.Property<string>("OperatingSystem")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductImage")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Ram")
                        .HasColumnType("longtext");

                    b.Property<string>("Rom")
                        .HasColumnType("longtext");

                    b.Property<string>("ScreenSize")
                        .HasColumnType("longtext");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("api.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IMEI")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("Id", "ProductId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("api.Models.WarehouseReceipt", b =>
                {
                    b.Property<string>("WarehouseReceiptId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("WarehouseReceiptId");

                    b.HasIndex("UserId");

                    b.ToTable("WarehouseReceipts");
                });

            modelBuilder.Entity("api.Models.WarehouseReceiptDetail", b =>
                {
                    b.Property<string>("WarehouseReceiptId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("WarehouseReceiptId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("WarehouseReceiptDetails");
                });

            modelBuilder.Entity("api.Models.Brand", b =>
                {
                    b.HasOne("api.Models.Brand", "ParentBrand")
                        .WithMany("SubBrands")
                        .HasForeignKey("ParentBrandId");

                    b.Navigation("ParentBrand");
                });

            modelBuilder.Entity("api.Models.Order", b =>
                {
                    b.HasOne("api.Models.ApplicationUser", null)
                        .WithMany("Orders")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("api.Models.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderType");
                });

            modelBuilder.Entity("api.Models.OrderDetail", b =>
                {
                    b.HasOne("api.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.HasOne("api.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId1");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("api.Models.ProductDetail", b =>
                {
                    b.HasOne("api.Models.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("api.Models.ProductDetail", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("api.Models.WarehouseReceipt", b =>
                {
                    b.HasOne("api.Models.ApplicationUser", "User")
                        .WithMany("WarehouseReceipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.WarehouseReceiptDetail", b =>
                {
                    b.HasOne("api.Models.Product", "Product")
                        .WithMany("WarehouseReceiptDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.WarehouseReceipt", "WarehouseReceipt")
                        .WithMany("WarehouseReceiptDetails")
                        .HasForeignKey("WarehouseReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WarehouseReceipt");
                });

            modelBuilder.Entity("api.Models.ApplicationUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WarehouseReceipts");
                });

            modelBuilder.Entity("api.Models.Brand", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubBrands");
                });

            modelBuilder.Entity("api.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductDetail");

                    b.Navigation("WarehouseReceiptDetails");
                });

            modelBuilder.Entity("api.Models.WarehouseReceipt", b =>
                {
                    b.Navigation("WarehouseReceiptDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
