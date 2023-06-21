using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApplication1
{
    public class MiDbContext : DbContext
    {
        public DbSet<Perfil> Perfiles { get; set; }

        private readonly IConfiguration _configuration;

        public MiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ADM");

            modelBuilder.Entity<Perfil>()
                .HasKey(p => new { p.PER_CODIGO, p.PER_NOMBRE });

            // Resto de la configuración del modelo
        }

    }
}
