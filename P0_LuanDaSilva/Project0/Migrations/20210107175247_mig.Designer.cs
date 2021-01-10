﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project0.Migrations
{
    [DbContext(typeof(Project0DbContext))]
    [Migration("20210107175247_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Models.BaseFloor", b =>
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

            modelBuilder.Entity("Models.FloorTourUsrLine", b =>
                {
                    b.Property<Guid>("FloorTourUsrLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FloorTourLineID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FloorTourUsrLineID");

                    b.ToTable("FloorTourUsrLines");
                });

            modelBuilder.Entity("Models.Painting", b =>
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

            modelBuilder.Entity("Models.Tour", b =>
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

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}