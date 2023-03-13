using DemoAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAuth.DB
{
    public class Seeder
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, DemoContext context)
        {
            await context.Database.EnsureCreatedAsync();
            if (!context.Users.Any())
            {
                List<string> roles = new() { "Admin", "Regular" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                List<AppUser> users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName = "John",
                        LastName = "James",
                        Email = "JJ@gmail.com",
                        UserName = "JJgh",
                        PhoneNumber = "080479379494"
                    },
                    new AppUser
                    {
                        FirstName = "Anne",
                        LastName = "Perry",
                        Email = "AnneP@gmail.com",
                        UserName = "Annie",
                        PhoneNumber = "080479379294"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Password2$");
                    if (user == users[0])
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "Regular");
                    }
                }
            }
        }


        //public static async Task SeedData(IServiceProvider serviceProvider, DemoContext context)
        //{

        //        await context.Database.EnsureCreatedAsync();
        //    using (UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>())
        //    {
        //        if (!context.Users.Any())
        //        {
        //            List<string> roles = new() { "Admin", "Regular" };
        //            using (RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
        //            {
        //                foreach (var role in roles)
        //                {
        //                    await roleManager.CreateAsync(new IdentityRole { Name = role });
        //                }

        //                List<AppUser> users = new List<AppUser>
        //        {
        //            new AppUser
        //            {
        //                FirstName = "John",
        //                LastName = "James",
        //                Email = "JJ@gmail.com",
        //                UserName = "JJgh",
        //                PhoneNumber = "080479379494"
        //            },
        //            new AppUser
        //            {
        //                FirstName = "Anne",
        //                LastName = "Perry",
        //                Email = "AnneP@gmail.com",
        //                UserName = "Annie",
        //                PhoneNumber = "080479379294"
        //            }
        //        };
        //                foreach (var user in users)
        //                {
        //                    await userManager.CreateAsync(user, "P@ssword");
        //                    if (user == users[0])
        //                    {
        //                        await userManager.AddToRoleAsync(user, "Admin");
        //                    }
        //                    else
        //                    {
        //                        await userManager.AddToRoleAsync(user, "Regular");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    await context.SaveChangesAsync();

        //}
    }
}
