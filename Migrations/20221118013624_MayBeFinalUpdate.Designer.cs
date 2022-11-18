﻿// <auto-generated />
using System;
using ITReportAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITReportAPI.Migrations
{
    [DbContext(typeof(ITReportContext))]
    [Migration("20221118013624_MayBeFinalUpdate")]
    partial class MayBeFinalUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ComponenteComputadora", b =>
                {
                    b.Property<int>("ComponentsId")
                        .HasColumnType("int");

                    b.Property<int>("ComputadorasId")
                        .HasColumnType("int");

                    b.HasKey("ComponentsId", "ComputadorasId");

                    b.HasIndex("ComputadorasId");

                    b.ToTable("ComponenteComputadora");
                });

            modelBuilder.Entity("ITReportAPI.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ITReportAPI.Models.CategoriaComputadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CategoriaComputadora");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Software"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Hardware"
                        });
                });

            modelBuilder.Entity("ITReportAPI.Models.CategoriaReporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CategoriasReporte");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Reporte"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Solicitud"
                        });
                });

            modelBuilder.Entity("ITReportAPI.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("ITReportAPI.Models.Computadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Gabinete")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Computadoras");
                });

            modelBuilder.Entity("ITReportAPI.Models.EstadoReporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EstadosReporte");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Pendiente"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Detenido"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Resuelto"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Nuevo"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Atendido"
                        });
                });

            modelBuilder.Entity("ITReportAPI.Models.Reporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("ComentariosAdmin")
                        .HasColumnType("longtext");

                    b.Property<string>("ComentariosReporte")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ComputadoraId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaDeReporte")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeIncidenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ComputadoraId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("SalaId");

                    b.HasIndex("TipoDeIncidenteId");

                    b.ToTable("Reportes");
                });

            modelBuilder.Entity("ITReportAPI.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Edificio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ITReportAPI.Models.TipoDeIncidente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaReporteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaReporteId");

                    b.ToTable("TiposDeIncidente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaReporteId = 1,
                            Nombre = "Sin Internet"
                        },
                        new
                        {
                            Id = 2,
                            CategoriaReporteId = 1,
                            Nombre = "No prende"
                        },
                        new
                        {
                            Id = 3,
                            CategoriaReporteId = 2,
                            Nombre = "Instalar"
                        },
                        new
                        {
                            Id = 4,
                            CategoriaReporteId = 2,
                            Nombre = "Optimizar"
                        });
                });

            modelBuilder.Entity("ComponenteComputadora", b =>
                {
                    b.HasOne("ITReportAPI.Models.Componente", null)
                        .WithMany()
                        .HasForeignKey("ComponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITReportAPI.Models.Computadora", null)
                        .WithMany()
                        .HasForeignKey("ComputadorasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITReportAPI.Models.Componente", b =>
                {
                    b.HasOne("ITReportAPI.Models.CategoriaComputadora", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ITReportAPI.Models.Computadora", b =>
                {
                    b.HasOne("ITReportAPI.Models.Sala", "Sala")
                        .WithMany("Computadoras")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ITReportAPI.Models.Reporte", b =>
                {
                    b.HasOne("ITReportAPI.Models.CategoriaReporte", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITReportAPI.Models.Computadora", "Computadora")
                        .WithMany("Reportes")
                        .HasForeignKey("ComputadoraId");

                    b.HasOne("ITReportAPI.Models.EstadoReporte", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITReportAPI.Models.Sala", "Sala")
                        .WithMany("Reportes")
                        .HasForeignKey("SalaId");

                    b.HasOne("ITReportAPI.Models.TipoDeIncidente", "Incidente")
                        .WithMany()
                        .HasForeignKey("TipoDeIncidenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Computadora");

                    b.Navigation("Estado");

                    b.Navigation("Incidente");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ITReportAPI.Models.TipoDeIncidente", b =>
                {
                    b.HasOne("ITReportAPI.Models.CategoriaReporte", "CategoriaReporte")
                        .WithMany()
                        .HasForeignKey("CategoriaReporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaReporte");
                });

            modelBuilder.Entity("ITReportAPI.Models.Computadora", b =>
                {
                    b.Navigation("Reportes");
                });

            modelBuilder.Entity("ITReportAPI.Models.Sala", b =>
                {
                    b.Navigation("Computadoras");

                    b.Navigation("Reportes");
                });
#pragma warning restore 612, 618
        }
    }
}
