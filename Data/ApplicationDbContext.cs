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
            // Ignore if this making a error in your ide
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Servidor> Servidor { get; set; }
    }
}