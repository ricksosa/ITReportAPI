using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Pomelo.EntityFrameworkCore.MySql;

namespace ITReportAPI.Models
{
    public class ITReportContext : DbContext
    {
        private const string connectionString = "server=143.198.147.10;port=3306;database=ITReportDB;user=root;password=my-secret-pw";
        public ITReportContext(DbContextOptions<ITReportContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Sala> Salas { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Reporte> Reportes { get; set; } = null!;
    }
}