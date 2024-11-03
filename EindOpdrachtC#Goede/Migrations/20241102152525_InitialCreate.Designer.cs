﻿// <auto-generated />
using System;
using EindOpdrachtC_Goede.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EindOpdrachtC_Goede.Migrations
{
    [DbContext(typeof(ZooContext))]
    [Migration("20241102152525_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityPattern")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DietaryClass")
                        .HasColumnType("int");

                    b.Property<int?>("EnclosureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityRequirement")
                        .HasColumnType("int");

                    b.Property<double>("SpaceRequirement")
                        .HasColumnType("float");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EnclosureId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Enclosure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Climate")
                        .HasColumnType("int");

                    b.Property<int>("HabitatType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityLevel")
                        .HasColumnType("int");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int?>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZooId");

                    b.ToTable("Enclosures");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Animal", b =>
                {
                    b.HasOne("EindOpdrachtC_Goede.Models.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EindOpdrachtC_Goede.Models.Enclosure", null)
                        .WithMany("Animals")
                        .HasForeignKey("EnclosureId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Enclosure", b =>
                {
                    b.HasOne("EindOpdrachtC_Goede.Models.Zoo", null)
                        .WithMany("Enclosures")
                        .HasForeignKey("ZooId");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Category", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Enclosure", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("EindOpdrachtC_Goede.Models.Zoo", b =>
                {
                    b.Navigation("Enclosures");
                });
#pragma warning restore 612, 618
        }
    }
}