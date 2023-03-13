using DemoAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAuth.DB
{
    public class DemoContext : IdentityDbContext<AppUser>
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }




       


    }
}