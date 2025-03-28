﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDb1.Data;

#nullable disable

namespace TestDb1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250327121041_Edit_Vehicle3")]
    partial class Edit_Vehicle3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("WebApp_Shared.Model.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Engine")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleasedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speed")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
