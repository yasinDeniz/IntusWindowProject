﻿// <auto-generated />
using System;
using DatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DatabaseAPI.Models.SubElement", b =>
                {
                    b.Property<int>("SubElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubElementId"));

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int?>("WindowId")
                        .HasColumnType("int");

                    b.HasKey("SubElementId");

                    b.HasIndex("WindowId");

                    b.ToTable("SubElement");
                });

            modelBuilder.Entity("DatabaseAPI.Models.Window", b =>
                {
                    b.Property<int>("WindowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WindowId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfWindows")
                        .HasColumnType("int");

                    b.Property<int>("TotalSubElements")
                        .HasColumnType("int");

                    b.HasKey("WindowId");

                    b.HasIndex("OrderId");

                    b.ToTable("Window");
                });

            modelBuilder.Entity("DatabaseAPI.Models.SubElement", b =>
                {
                    b.HasOne("DatabaseAPI.Models.Window", null)
                        .WithMany("SubElements")
                        .HasForeignKey("WindowId");
                });

            modelBuilder.Entity("DatabaseAPI.Models.Window", b =>
                {
                    b.HasOne("DatabaseAPI.Models.Order", null)
                        .WithMany("Windows")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("DatabaseAPI.Models.Order", b =>
                {
                    b.Navigation("Windows");
                });

            modelBuilder.Entity("DatabaseAPI.Models.Window", b =>
                {
                    b.Navigation("SubElements");
                });
#pragma warning restore 612, 618
        }
    }
}