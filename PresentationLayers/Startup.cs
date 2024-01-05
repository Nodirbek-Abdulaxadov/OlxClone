using DataAccesLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace PresentationLayers;

public static class Startup
{
    public static async void SeedRolesToDatabase(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var roleManager = scope.ServiceProvider
                               .GetRequiredService<RoleManager<IdentityRole>>();

        if (!roleManager.Roles.Any())
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "SuperAdmin" },
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "User" }
            };

            foreach (var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }
        }

        var userManager = scope.ServiceProvider
                               .GetRequiredService<UserManager<User>>();

        var user = new User()
        {
            FullName = "Super Admin",
            PhoneNumber = "+998901234567",
            UserName = "+998901234567",
            PhoneNumberConfirmed = true
        };

        var userExist = await userManager.FindByNameAsync(user.UserName);
        if (userExist == null)
        {
            await userManager.CreateAsync(user, "Admin.123$");
            await userManager.AddToRoleAsync(user, "SuperAdmin");
        }
    }
}