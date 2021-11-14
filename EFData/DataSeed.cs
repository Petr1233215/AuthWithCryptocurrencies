using DomainProject;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace EFData
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    UserName = "TestUser",
                    Email = "testuser@test.com"
                };

                await userManager.CreateAsync(user, "ababX123!");
            }
        }
    }
}
