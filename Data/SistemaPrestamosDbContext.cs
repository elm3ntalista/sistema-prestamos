using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Models;

namespace SistemaPrestamos.Data
{
    public class SistemaPrestamosDbContext : DbContext
    {
        public SistemaPrestamosDbContext(DbContextOptions<SistemaPrestamosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<ReciboCobro> RecibosCobro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamo>()
               .HasOne(p => p.Cliente)
               .WithMany(c => c.Prestamos)
               .HasForeignKey(p => p.ClienteId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReciboCobro>()
               .HasOne(rc => rc.Prestamo)
               .WithMany(p => p.RecibosCobro)
               .HasForeignKey(rc => rc.PrestamoId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReciboCobro>()
                .HasOne(rc => rc.Cliente)
                .WithMany(c => c.RecibosCobro)
                .HasForeignKey(rc => rc.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}