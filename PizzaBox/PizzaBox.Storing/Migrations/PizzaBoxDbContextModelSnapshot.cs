﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxDbContext))]
    partial class PizzaBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("CrustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CrustId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Crust");

                    b.HasData(
                        new
                        {
                            CrustId = 637190174828762899L,
                            Name = "Thin Crust",
                            Price = 2.00m
                        },
                        new
                        {
                            CrustId = 637190174828763715L,
                            Name = "New York Style",
                            Price = 3.00m
                        },
                        new
                        {
                            CrustId = 637190174828763743L,
                            Name = "Deep Dish",
                            Price = 4.00m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CrustId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SizeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ToppingId")
                        .HasColumnType("bigint");

                    b.HasKey("PizzaId");

                    b.HasIndex("CrustId");

                    b.HasIndex("SizeId");

                    b.HasIndex("ToppingId");

                    b.ToTable("Pizza");

                    b.HasData(
                        new
                        {
                            PizzaId = 637190174828732536L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SizeId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Size");

                    b.HasData(
                        new
                        {
                            SizeId = 637190174828764332L,
                            Name = "Small",
                            Price = 7.00m
                        },
                        new
                        {
                            SizeId = 637190174828764573L,
                            Name = "Medium",
                            Price = 10.00m
                        },
                        new
                        {
                            SizeId = 637190174828764583L,
                            Name = "Large",
                            Price = 12.00m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("ToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ToppingId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Topping");

                    b.HasData(
                        new
                        {
                            ToppingId = 637190174828765157L,
                            Name = "Cheese",
                            Price = 0.25m
                        },
                        new
                        {
                            ToppingId = 637190174828765391L,
                            Name = "Sauce",
                            Price = 0.50m
                        },
                        new
                        {
                            ToppingId = 637190174828765405L,
                            Name = "Pepperonni",
                            Price = 0.75m
                        },
                        new
                        {
                            ToppingId = 637190174828765407L,
                            Name = "Bacon",
                            Price = 1.00m
                        },
                        new
                        {
                            ToppingId = 637190174828765409L,
                            Name = "Pinneapple",
                            Price = 1.00m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustId");

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId");

                    b.HasOne("PizzaBox.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingId");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany("Toppings")
                        .HasForeignKey("PizzaId");
                });
#pragma warning restore 612, 618
        }
    }
}
