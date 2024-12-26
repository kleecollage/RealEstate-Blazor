using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertiesServer.Data;

namespace PropertiesServer.Services;

public class DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager): IDbInitializer
{
    public void Initialize()
    {
        try
        {
            if (context.Database.GetPendingMigrations().Count() > 0)
            {
                context.Database.Migrate();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        if (context.Roles.Any(x => x.Name == Configurations.RoleAdmin)) return;
        
        roleManager.CreateAsync(new IdentityRole(Configurations.RoleAdmin)).GetAwaiter().GetResult();
        roleManager.CreateAsync(new IdentityRole(Configurations.RolePublisher)).GetAwaiter().GetResult();
        
        userManager.CreateAsync(new ApplicationUser
        {
            UserName = "admin@mail.com",
            Email = "admin@mail.com",
            EmailConfirmed = true,
        }, "Admin123*").GetAwaiter().GetResult();
        
        ApplicationUser user = context.Users.FirstOrDefault(u => u.Email == "admin@mail.com");
        userManager.AddToRoleAsync(user, Configurations.RoleAdmin).GetAwaiter().GetResult();
    }
}









