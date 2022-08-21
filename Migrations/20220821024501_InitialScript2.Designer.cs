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
    [Migration("20220821024501_InitialScript2")]
    partial class InitialScript2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                });

            modelBuilder.Entity("ITReportAPI.Models.Componente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("ComputadoraId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ComputadoraId");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("ITReportAPI.Models.Computadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Gabinete")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdSala")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Computadora");
                });

            modelBuilder.Entity("ITReportAPI.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Edificio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ITReportAPI.Models.Componente", b =>
                {
                    b.HasOne("ITReportAPI.Models.CategoriaComputadora", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITReportAPI.Models.Computadora", null)
                        .WithMany("Components")
                        .HasForeignKey("ComputadoraId");

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

            modelBuilder.Entity("ITReportAPI.Models.Computadora", b =>
                {
                    b.Navigation("Components");
                });

            modelBuilder.Entity("ITReportAPI.Models.Sala", b =>
                {
                    b.Navigation("Computadoras");
                });
#pragma warning restore 612, 618
        }
    }
}
