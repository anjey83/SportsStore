﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsStore.Models;

namespace SportsStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsStore.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("SportsStore.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("GiftWrap");

                    b.Property<string>("Line1")
                        .IsRequired();

                    b.Property<string>("Line2");

                    b.Property<string>("Line3");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Shipped");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Zip");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SportsStore.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SportsStore.Models.CartLine", b =>
                {
                    b.HasOne("SportsStore.Models.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("SportsStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}
