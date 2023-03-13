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

//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("DemoAuthAPIBearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        Description = "JWT Authorization header using the Bearer scheme."
//    });

//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "DemoAuthAPIBearer"
//                }
//            }, new List<string>() }
//    });
//});

//builder.Services.AddDbContext<DemoContext>(options =>
//{
//    options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]);
//});

//builder.Services.AddScoped<IAuthentication, Authentication>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

builder.Services.Extensions(builder.Configuration);
builder.Services.IdentityExtensions(builder.Configuration);

//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<DemoContext>()
//    .AddDefaultTokenProviders();


//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//    options.Password.RequiredLength = 7;
//});



//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateAudience = true,//who can call the api
//        ValidateIssuer = true, //who issued the token
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidAudience = builder.Configuration["JWTSettings:Audience"],
//        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:SecretKey"])),
//        ClockSkew = TimeSpan.Zero //grace period after the token expires
//    };
//});

builder.Services.AddOpenApiDocumentation();

var app = builder.Build();


//using (var scope = app.Services.CreateScope()) 
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<DemoContext>();
//    var role = services.GetRequiredService<RoleManager<IdentityRole>>();
//    var user = services.GetRequiredService<UserManager<AppUser>>();
//    Seeder.Seed(role,user,context).Wait();
//}


//Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
   // app.UseSwaggerUI();
    app.EnsureDatabaseSetup();
}

app.UseHttpsRedirection();
app.UseOpenApiDocumentation();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
