﻿// <auto-generated />
using System;
using EletronicECommerce.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EletronicECommerce.Repository.Migrations
{
    [DbContext(typeof(EletronicECommerceContext))]
    partial class EletronicECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EletronicECommerce.Repository.Models.CategoryModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("Pk_Category");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.CustomerModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id")
                        .HasName("Pk_User");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.OrderModel", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.ProductModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id")
                        .HasName("Pk_Product");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.SubModels.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10)")
                        .HasDefaultValue("S/N");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id")
                        .HasName("Pk_Address");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.SubModels.StockModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("Pk_Stock");

                    b.ToTable("ProductStock");
                });

            modelBuilder.Entity("EletronicECommerce.Repository.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id")
                        .HasName("Pk_User");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
