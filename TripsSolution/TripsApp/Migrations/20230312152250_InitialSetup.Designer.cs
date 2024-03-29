﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripsApp.Models;

#nullable disable

namespace TripsApp.Migrations
{
    [DbContext(typeof(TripLogContext))]
    [Migration("20230312152250_InitialSetup")]
    partial class InitialSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripsApp.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<string>("Accommodation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ThingToDo1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            TripId = 1,
                            Accommodation = "",
                            AccommodationEmail = "",
                            AccommodationPhone = "",
                            Destination = "Boise",
                            EndDate = new DateTime(2023, 6, 14, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 6, 6, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            ThingToDo1 = "Visit Tammy",
                            ThingToDo2 = "",
                            ThingToDo3 = ""
                        },
                        new
                        {
                            TripId = 2,
                            Accommodation = "The Benson Hotel",
                            AccommodationEmail = "staff@bensonhotel.com",
                            AccommodationPhone = "503-555-1234",
                            Destination = "Portland",
                            EndDate = new DateTime(2024, 1, 7, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            ThingToDo1 = "Go to Voodoo Doughnuts",
                            ThingToDo2 = "Walk in the rain",
                            ThingToDo3 = "Go to Powell's"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
