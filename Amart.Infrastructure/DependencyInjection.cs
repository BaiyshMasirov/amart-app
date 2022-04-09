using Amart.Application.Common.Interfaces;
using Amart.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amart.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAmartInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AmartEFContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("AmartConnection")));

            services.AddScoped<IAmartEFContext>(provider => provider.GetService<AmartEFContext>());

            return services;
        }
    }
}