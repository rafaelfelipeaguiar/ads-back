using Microsoft.EntityFrameworkCore;
using CrudVeiculos.Entities;

namespace CrudVeiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Servidor> Servidor { get; set; }
        public DbSet<CorpoDocente> CorpoDocente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorpoDocente>()
            .HasOne(cd => cd.Servidor)
            .WithOne(s => s.CorpoDocente)
            .HasForeignKey<CorpoDocente>(cd => cd.ServidorId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}