using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Interfaces;
using API.Services;
using System.Reflection.Metadata.Ecma335;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
        
            return services;
        }
    }
}