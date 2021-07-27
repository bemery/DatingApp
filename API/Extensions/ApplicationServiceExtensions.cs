using API.Interfaces;
using API.Services;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<Data.DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            }
            );

            return services;

        }
    }
}