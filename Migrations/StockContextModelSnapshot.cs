﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COP4365_Project3.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Close")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("High")
                        .HasColumnType("REAL");

                    b.Property<double>("Low")
                        .HasColumnType("REAL");

                    b.Property<double>("Open")
                        .HasColumnType("REAL");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StockFilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Volume")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Stock");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SmartStock", b =>
                {
                    b.HasBaseType("Stock");

                    b.Property<double>("BodyRange")
                        .HasColumnType("REAL");

                    b.Property<double>("BottomPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("BottomTail")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsBearish")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBullish")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDoji")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDragonFlyDoji")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGravestoneDoji")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHammer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInvertedHammer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMarubozu")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNeutral")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TopPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("TopTail")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("SmartStock");
                });
#pragma warning restore 612, 618
        }
    }
}
