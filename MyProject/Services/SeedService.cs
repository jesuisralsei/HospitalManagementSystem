using Microsoft.AspNetCore.Identity;
using MyProject.Data;
using MyProject.Roles;

namespace MyProject.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Ensuring the database is created");
                await context.Database.EnsureCreatedAsync();

                //Add Roles
                logger.LogInformation("seeding roles");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                //Add Admin User
                logger.LogInformation("seeding admin user");
                var adminEmail = "admin@codehub.com";
                if(await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        FullName = "Mohamed",
                        UserName = adminEmail
                        ,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("assining admin role to this user");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("failed to create admin user", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

            }
            catch (Exception ex) {
                logger.LogError(ex, "an error occured making the database");
            }
        }
        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                throw new Exception($"Failed to create role {roleName} : {string.Join(", ", result.Errors.Select(e => e.Description))}"); }
        }
    }
}
