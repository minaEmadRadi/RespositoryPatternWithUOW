using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = services.GetRequiredService<UserManager<Customer>>();
                    SeedRolesAndAdminUser(roleManager,userManager).Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                    // Log errors or handle exceptions
                }
            }

            host.Run();
        }
        private static async Task SeedRolesAndAdminUser(RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
            }
            var adminUserName = "admin@example.com";
            var adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser == null)
            {
                adminUser = new Customer { CustomerName = adminUserName, UserName = adminUserName, Email = adminUserName };
                await userManager.CreateAsync(adminUser, "AdminPassword123!"); 
                await userManager.AddToRoleAsync(adminUser, UserRoles.Admin);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
