using DomainProject;
using EFData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
namespace AuthWithCryptocurrencies
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
                    var dbContext = services.GetRequiredService<ApplicationContext>();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    dbContext.Database.Migrate();

                    DataSeed.SeedDataAsync(userManager).Wait();
                }
                catch (Exception ex)
                {
                    //To-Do: дописать обработку
                }
                
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
