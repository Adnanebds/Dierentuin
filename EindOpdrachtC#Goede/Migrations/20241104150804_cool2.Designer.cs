﻿// <auto-generated />
using System;
using Dierentuin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EindOpdrachtC_Goede.Migrations
{
    [DbContext(typeof(ZooContext))]
    [Migration("20241104150804_cool2")]
    partial class cool2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityPattern")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Diet")
                        .HasColumnType("int");

                    b.Property<int?>("EnclosureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecurityRequirement")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<double>("SpaceRequirement")
                        .HasColumnType("float");

                    b.Property<string>("Species")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EnclosureId");

                    b.HasIndex("ZooId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Dierentuin.Models.Category", b =>
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

            modelBuilder.Entity("Dierentuin.Models.Enclosure", b =>
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

            modelBuilder.Entity("Dierentuin.Models.Zoo", b =>
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

            modelBuilder.Entity("Animal", b =>
                {
                    b.HasOne("Animal", null)
                        .WithMany("Prey")
                        .HasForeignKey("AnimalId");

                    b.HasOne("Dierentuin.Models.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Dierentuin.Models.Enclosure", "Enclosure")
                        .WithMany("Animals")
                        .HasForeignKey("EnclosureId");

                    b.HasOne("Dierentuin.Models.Zoo", null)
                        .WithMany("Animals")
                        .HasForeignKey("ZooId");

                    b.Navigation("Category");

                    b.Navigation("Enclosure");
                });

            modelBuilder.Entity("Dierentuin.Models.Enclosure", b =>
                {
                    b.HasOne("Dierentuin.Models.Zoo", null)
                        .WithMany("Enclosures")
                        .HasForeignKey("ZooId");
                });

            modelBuilder.Entity("Animal", b =>
                {
                    b.Navigation("Prey");
                });

            modelBuilder.Entity("Dierentuin.Models.Category", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Dierentuin.Models.Enclosure", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Dierentuin.Models.Zoo", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Enclosures");
                });
#pragma warning restore 612, 618
        }
    }
}
