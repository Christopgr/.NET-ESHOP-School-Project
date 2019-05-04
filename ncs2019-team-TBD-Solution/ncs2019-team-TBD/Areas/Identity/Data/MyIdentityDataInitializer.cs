using Microsoft.AspNetCore.Identity;
using ncs2019_team_TBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Areas.Identity.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);

        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("Whakakai").Result == null)
            {
                User user = new User();
                user.UserName = "Whakakai";
                user.Email = "whakakai@whakakai.com";
                user.PhoneNumber = " ";
                user.Address = " ";
                user.AddressNumber = 0;
                user.City = " ";
                user.FirstName = " ";
                user.LastName = " ";
                user.ZipCode = 0;

                IdentityResult result = userManager.CreateAsync(user, "Anastasia89!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }

            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customer";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult identityResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
