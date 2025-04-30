using ApiAds.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAds.DataContexts
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Servidor> Servidor { get; set; }

    }
}
