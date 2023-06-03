using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Pomelo.EntityFrameworkCore.MySql;

namespace ITReportAPI.Models
{
    public class ITReportContext : DbContext
    {
        private const string connectionString = "server=localhost;port=1433;database=master;user=sa;password=yourStrong_Password";
        public ITReportContext(DbContextOptions<ITReportContext> options)
            : base(options)
        {
        }

        public ITReportContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaReporte>()
            .HasData(
                new CategoriaReporte() { Id = 1, Nombre = "Reporte" },
                new CategoriaReporte() { Id = 2, Nombre = "Solicitud" }
            );
            modelBuilder.Entity<EstadoReporte>()
            .HasData(
                new EstadoReporte() { Id = 1, Nombre = "Pendiente" },
                new EstadoReporte() { Id = 2, Nombre = "Detenido" },
                new EstadoReporte() { Id = 3, Nombre = "Resuelto" },
                new EstadoReporte() { Id = 4, Nombre = "Nuevo" },
                new EstadoReporte() { Id = 5, Nombre = "Atendido" }
            );
            modelBuilder.Entity<TipoDeIncidente>()
                .HasData(
                    new TipoDeIncidente() { Id = 1, Nombre = "Sin Internet", CategoriaReporteId = (int)Categoria.Reporte },
                    new TipoDeIncidente() { Id = 2, Nombre = "No prende", CategoriaReporteId = (int)Categoria.Reporte },
                    new TipoDeIncidente() { Id = 3, Nombre = "Instalar", CategoriaReporteId = (int)Categoria.Solicitud },
                    new TipoDeIncidente() { Id = 4, Nombre = "Optimizar", CategoriaReporteId = (int)Categoria.Solicitud }
                );
            modelBuilder.Entity<CategoriaComputadora>()
                .HasData(
                    new CategoriaComputadora() { Id = 1, Nombre = "Software" },
                    new CategoriaComputadora() { Id = 2, Nombre = "Hardware" }
                );
        }

        public DbSet<Sala> Salas { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Reporte> Reportes { get; set; } = null!;
        public DbSet<Computadora> Computadoras { get; set; } = null!;
        public DbSet<Componente> Componentes { get; set; } = null!;
        public DbSet<CategoriaReporte> CategoriasReporte { get; set; } = null!;
        public DbSet<TipoDeIncidente> TiposDeIncidente { get; set; } = null!;
        public DbSet<EstadoReporte> EstadosReporte { get; set; } = null!;
    }
    public enum CategoriaComponent
    {
        Software = 1,
        Hardware = 2
    }
    public enum Categoria
    {
        Reporte = 1,
        Solicitud = 2
    }
    public enum Tipo
    {
        SinInternet = 1,
        NoPrende = 2,
        Instalar = 3,
        Optimizar = 4
    }
}