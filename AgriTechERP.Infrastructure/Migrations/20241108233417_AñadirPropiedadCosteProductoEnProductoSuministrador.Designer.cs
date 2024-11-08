﻿// <auto-generated />
using System;
using AgriTechERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgriTechERP.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241108233417_AñadirPropiedadCosteProductoEnProductoSuministrador")]
    partial class AñadirPropiedadCosteProductoEnProductoSuministrador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgriTechERP.Core.Entidades.InventarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrdenCarritoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoSuministradorId")
                        .HasColumnType("int");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenCarritoId");

                    b.HasIndex("ProductoSuministradorId");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.OrdenCarritoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Aprobacion")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ProductoSuministradorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoSuministradorId");

                    b.ToTable("OrdenCarritos");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.ProduccionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EstadoProductoProduccion")
                        .HasColumnType("int");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductosProduccion");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.ProductoSuministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CosteProducto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProduccionModelId")
                        .HasColumnType("int");

                    b.Property<int>("SuministradorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduccionModelId");

                    b.HasIndex("SuministradorId");

                    b.ToTable("ProductosSuministradores");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.SuministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CIF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoContacto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suministradores");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.InventarioModel", b =>
                {
                    b.HasOne("AgriTechERP.Core.Entidades.OrdenCarritoModel", "OrdenCarrito")
                        .WithMany()
                        .HasForeignKey("OrdenCarritoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AgriTechERP.Core.Entidades.ProductoSuministradorModel", "ProductoSuministrador")
                        .WithMany()
                        .HasForeignKey("ProductoSuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenCarrito");

                    b.Navigation("ProductoSuministrador");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.OrdenCarritoModel", b =>
                {
                    b.HasOne("AgriTechERP.Core.Entidades.ProductoSuministradorModel", "ProductoSuministrador")
                        .WithMany()
                        .HasForeignKey("ProductoSuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductoSuministrador");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.ProductoSuministradorModel", b =>
                {
                    b.HasOne("AgriTechERP.Core.Entidades.ProduccionModel", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("ProduccionModelId");

                    b.HasOne("AgriTechERP.Core.Entidades.SuministradorModel", "Suministrador")
                        .WithMany()
                        .HasForeignKey("SuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suministrador");
                });

            modelBuilder.Entity("AgriTechERP.Core.Entidades.ProduccionModel", b =>
                {
                    b.Navigation("Ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
