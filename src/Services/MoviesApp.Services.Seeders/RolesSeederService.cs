using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Data.Models;

namespace MoviesApp.Services.Seeders
{
    public static class RolesSeederService
    {

        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleNames = DeclareRoles();
            var Configuration = configuration;
            //adding custom roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<MoviesAppUser>>();
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //creating a super user who could maintain the web app
            var poweruser = new MoviesAppUser
            {
                UserName = Configuration.GetSection("UserSettings")["UserEmail"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };
            string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];
            var _user = await userManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);
            if (_user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await userManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }

        private static string[] DeclareRoles()
        {

            return new string[] { "Admin", "User" };
        }
    }
}
