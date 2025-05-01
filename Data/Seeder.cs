using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Data
{
    public static class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.MarcasVeiculo.Any() || context.Cores.Any())
            {
                return;
            }

            context.MarcasVeiculo.AddRange(
                new MarcaVeiculo { NomeMarca = "Ford" },
                new MarcaVeiculo { NomeMarca = "Chevrolet" }
            );

            context.Cores.AddRange(
                new Cor { NomeCor = "Preto" },
                new Cor { NomeCor = "Branco" }
            );

            context.SaveChanges();
        }
    }
}
