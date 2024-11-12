using CrazyApi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CrazyApi.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DBConnection"];
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IApiDbContext>(provider =>
            provider.GetService<ApiDbContext>());

            return services;
        }
    }
}
