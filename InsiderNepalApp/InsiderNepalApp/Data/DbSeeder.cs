using InsiderNepalApp.Areas.Identity.Data;
using InsiderNepalApp.Constants;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace InsiderNepalApp.Data;

public class DbSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
    {
        //Seed Roles
        var userManager = service.GetService<UserManager<InsiderNepalAppUser>>();
        var roleManager = service.GetService<RoleManager<IdentityRole>>();
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

        var user = new InsiderNepalAppUser
        {
            UserName = "sam@gmail.com",
            Email = "sam@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,

        };
        var userInDb = await userManager.FindByEmailAsync(user.Email);
        if (userInDb == null)
        {
            await userManager.CreateAsync(user, "Admin@123");
            await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
        }
    }
}
