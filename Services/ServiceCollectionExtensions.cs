using Microsoft.Extensions.DependencyInjection;
using CrudVeiculos.Services;

namespace CrudVeiculos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ServidorService>();
            return services;
        }
    }
}
