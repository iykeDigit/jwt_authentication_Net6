using DemoAuth.API;
using DemoAuth.Core;
using DemoAuth.DB;
using DemoAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Extensions(builder.Configuration);
builder.Services.IdentityExtensions(builder.Configuration);
builder.Services.AddOpenApiDocumentation();

var app = builder.Build();

//Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
   app.EnsureDatabaseSetup();
}

app.UseHttpsRedirection();
app.UseOpenApiDocumentation();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
