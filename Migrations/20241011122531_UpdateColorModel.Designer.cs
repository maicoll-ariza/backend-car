﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehiculosApi.Data;

#nullable disable

namespace VehiculosApi.Migrations
{
    [DbContext(typeof(VehiculosContext))]
    [Migration("20241011122531_UpdateColorModel")]
    partial class UpdateColorModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("VehiculosApi.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Rojo"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Azul"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Negro"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Blanco"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Gris"
                        });
                });

            modelBuilder.Entity("VehiculosApi.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Toyota"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Chevrolet"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Honda"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "BMW"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Audi"
                        });
                });

            modelBuilder.Entity("VehiculosApi.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anio")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("VehiculosApi.Models.Vehiculo", b =>
                {
                    b.HasOne("VehiculosApi.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehiculosApi.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Marca");
                });
#pragma warning restore 612, 618
        }
    }
}
