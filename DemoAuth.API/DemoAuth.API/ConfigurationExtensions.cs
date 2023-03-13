using DemoAuth.DB;
using DemoAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace DemoAuth.API
{
    public static class ConfigurationExtensions
    {
        public static void AddOpenApiDocumentation(this IServiceCollection services) 
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("DemoAuthAPIBearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "DemoAuthAPIBearer"
                            }
                        }, new List<string>() 
                    }
                });
            });
        }

        public static void UseOpenApiDocumentation(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoAuth API V1"); });
        }

        public static void EnsureDatabaseSetup(this WebApplication app) 
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DemoContext>();
            var role = services.GetRequiredService<RoleManager<IdentityRole>>();
            var user = services.GetRequiredService<UserManager<AppUser>>();
            Seeder.Seed(role, user, context).Wait();
        }
    }
}
