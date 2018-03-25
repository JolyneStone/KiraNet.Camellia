using System.Linq;
using System.Threading.Tasks;
using KiraNet.Camellia.AuthorizationServer.Configuration;
using KiraNet.Camellia.AuthorizationServer.Data;
using KiraNet.Camellia.AuthorizationServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KiraNet.Camellia.AuthorizationServer.Extensions
{
    public static class DatabaseExtensions
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var authDbContext = serviceScope.ServiceProvider.GetRequiredService<AuthDbContext>();
                authDbContext.Database.Migrate();

                //var configurationDbContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                //configurationDbContext.Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManagr = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                Task.Run(async () =>
                {
                    var admin = await userManager.FindByNameAsync("admin");
                    if (admin == null)
                    {
                        await userManager.CreateAsync(new User
                        {
                            UserName = "admin",
                            Email = "997525106@qq.com",
                            EmailConfirmed = true,
                            AccessFailedCount = 0,
                            LockoutEnabled = false
                        }, "zi123123");
                    }

                    var adminRole = await roleManagr.FindByNameAsync("admin");
                    if (adminRole == null)
                    {
                        adminRole = new IdentityRole()
                        {
                            Name = "admin"
                        };

                        await roleManagr.CreateAsync(adminRole);
                    }

                    if (!await userManager.IsInRoleAsync(admin, "admin"))
                    {
                        await userManager.AddToRoleAsync(admin, "admin");
                    }

                }).GetAwaiter().GetResult();

                //if (!configurationDbContext.Clients.Any())
                //{
                //    foreach (var client in IdentityServerConfig.GetClients())
                //    {
                //        configurationDbContext.Clients.Add(client.ToEntity());
                //    }
                //    configurationDbContext.SaveChanges();
                //}

                //if (!configurationDbContext.IdentityResources.Any())
                //{
                //    foreach (var resource in IdentityServerConfig.GetIdentityResources())
                //    {
                //        configurationDbContext.IdentityResources.Add(resource.ToEntity());
                //    }
                //    configurationDbContext.SaveChanges();
                //}

                //if (!configurationDbContext.ApiResources.Any())
                //{
                //    foreach (var resource in IdentityServerConfig.GetApiResources())
                //    {
                //        configurationDbContext.ApiResources.Add(resource.ToEntity());
                //    }
                //    configurationDbContext.SaveChanges();
                //}
            }
        }
    }
}
