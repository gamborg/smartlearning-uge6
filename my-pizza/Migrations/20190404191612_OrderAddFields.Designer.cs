﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using my_pizza.Models;

namespace my_pizza.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20190404191612_OrderAddFields")]
    partial class OrderAddFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("my_pizza.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Durum"
                        });
                });

            modelBuilder.Entity("my_pizza.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("Discount");

                    b.Property<int>("Fee");

                    b.Property<int>("Status");

                    b.Property<int>("Tips");

                    b.Property<int>("Total");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Vat");

                    b.Property<string>("_customer")
                        .HasColumnName("customer");

                    b.Property<string>("_products")
                        .HasColumnName("products");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("my_pizza.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Qty");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Tomat, ost og skinke",
                            Name = "Vesuvio",
                            Price = 69.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Tomat, ost, paprika, champignon, ananas, asparges og løg",
                            Name = "Vegetariana",
                            Price = 74.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Tomat, ost, skinke og ananas",
                            Name = "Hawaii",
                            Price = 71.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Tomat, ost og pepperoni",
                            Name = "Pepperoni",
                            Price = 69.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Tomat, ost, skinke og champignon",
                            Name = "Capricciosa",
                            Price = 73.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Serveres med salat og dressing",
                            Name = "Kylling Durum",
                            Price = 59.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Serveres med salat og dressing",
                            Name = "Kebab Durum",
                            Price = 59.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Serveres med salat og dressing",
                            Name = "Græsk Bøf Durum",
                            Price = 59.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Serveres med salat og dressing",
                            Name = "Falafel Durum",
                            Price = 59.0,
                            Qty = 0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Serveres med salat og dressing",
                            Name = "Skinke Durum",
                            Price = 59.0,
                            Qty = 0
                        });
                });

            modelBuilder.Entity("my_pizza.Models.Product", b =>
                {
                    b.HasOne("my_pizza.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
