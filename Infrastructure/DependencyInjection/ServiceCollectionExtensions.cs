using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromomashTest.Application.Interfaces;
using PromomashTest.Infrastructure.Data;
using PromomashTest.Infrastructure.Repositories;

namespace PromomashTest.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
