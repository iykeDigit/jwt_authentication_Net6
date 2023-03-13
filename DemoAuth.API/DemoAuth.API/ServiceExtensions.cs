using DemoAuth.Core;
using DemoAuth.DB;
using DemoAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using System.Runtime.CompilerServices;

namespace DemoAuth.API
{
    public static class ServiceExtensions
    {
        public static void Extensions(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSqlite<DemoContext>(connectionString);
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            
        }
    }
}
