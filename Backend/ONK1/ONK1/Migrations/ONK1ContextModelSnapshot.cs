﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(ONK1Context))]
    partial class ONK1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Haandvaerker", b =>
                {
                    b.Property<int>("HaandvaerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HVAnsaettelsesdato")
                        .HasColumnType("datetime2");

                    b.Property<string>("HVEfternavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFagomraade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HVFornavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HaandvaerkerId");

                    b.ToTable("Haandvaerker");
                });

            modelBuilder.Entity("Backend.Models.Vaerktoej", b =>
                {
                    b.Property<int>("VTId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LiggerIVTK")
                        .HasColumnType("int");

                    b.Property<DateTime>("VTAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<string>("VTFabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTSerienummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VTId");

                    b.HasIndex("LiggerIVTK");

                    b.ToTable("Vaerktoej");
                });

            modelBuilder.Entity("Backend.Models.Vaerktoejskasse", b =>
                {
                    b.Property<int>("VTKId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("VTKAnskaffet")
                        .HasColumnType("datetime2");

                    b.Property<int>("VTKEjesAf")
                        .HasColumnType("int");

                    b.Property<string>("VTKFarve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKSerienummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VTKfabrikat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VTKId");

                    b.HasIndex("VTKEjesAf");

                    b.ToTable("Vaerktoejskasse");
                });

            modelBuilder.Entity("Backend.Models.Vaerktoej", b =>
                {
                    b.HasOne("Backend.Models.Vaerktoejskasse", "Vaerktoejskasse")
                        .WithMany("Vaerktoejer")
                        .HasForeignKey("LiggerIVTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Vaerktoejskasse", b =>
                {
                    b.HasOne("Backend.Models.Haandvaerker", "Haandvaerker")
                        .WithMany("Vaerktoejskasser")
                        .HasForeignKey("VTKEjesAf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}