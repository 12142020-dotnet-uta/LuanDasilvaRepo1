﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project0;

namespace Project0.Migrations
{
    [DbContext(typeof(Project0DbContext))]
    [Migration("20201230010044_ReworkMigration")]
    partial class ReworkMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Project0.BaseFloor", b =>
                {
                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LocationRemainingTours")
                        .HasColumnType("int");

                    b.Property<int>("LocationSize")
                        .HasColumnType("int");

                    b.HasKey("LocationCodeName");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("Project0.FloorTourLine", b =>
                {
                    b.Property<Guid>("FloorTourLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FloorTourLineID");

                    b.ToTable("FloorTourLines");
                });

            modelBuilder.Entity("Project0.FloorTourUsrLine", b =>
                {
                    b.Property<Guid>("FloorTourLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FloorTourUsrLineID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FloorTourLineID");

                    b.ToTable("FloorTourUsrLines");
                });

            modelBuilder.Entity("Project0.Painting", b =>
                {
                    b.Property<Guid>("PaintingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaintingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("PaintingID");

                    b.ToTable("Paintings");
                });

            modelBuilder.Entity("Project0.Tour", b =>
                {
                    b.Property<Guid>("TourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RowNum")
                        .HasColumnType("int");

                    b.HasKey("TourID");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Project0.User", b =>
                {
                    b.Property<Guid>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
