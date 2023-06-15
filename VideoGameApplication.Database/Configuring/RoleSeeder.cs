using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Database.Configuring
{
	public static class RoleSeeder
	{

		public static async Task Seed(RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
		{
			await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
			await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

			var user = new User() { UserName = "chadmin@gmail.com", Email = "chadmin@gmail.com" };
			var hashedPassword = userManager.PasswordHasher.HashPassword(user, "Password123+");
			user.PasswordHash = hashedPassword;

			await userManager.CreateAsync(user);
			await userManager.AddToRoleAsync(user, "Admin");
		}
	}
}
