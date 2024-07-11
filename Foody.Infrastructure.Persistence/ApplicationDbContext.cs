using Foody.Core.Domain.Enums;
using Foody.Infrastructure.Persistence.Configurations;
using Foody.Infrastructure.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foody.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            base.OnModelCreating(builder);
        }

        public async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            bool anyUser = await Users.AnyAsync();

            if (anyUser) return;

            var managerRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = nameof(ApplicationRoles.Manager)
            };

            var waiterRole = new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = nameof(ApplicationRoles.Waiter)
            };

            await roleManager.CreateAsync(managerRole);
            await roleManager.CreateAsync(waiterRole);

            var manager = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Name = "Admin",
                Lastname = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "manager@gmail.com"
            };

            var waiter = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "waiter",
                Name = "Waiter",
                Lastname = "Waiter",
                NormalizedUserName = "WAITER",
                Email = "waiter@gmail.com"
            };

            var super = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "super",
                Name = "Super",
                Lastname = "Super",
                NormalizedUserName = "SUPER",
                Email = "super@gmail.com"
            };

            string password = "Password123!";

            await userManager.CreateAsync(manager, password);
            await userManager.CreateAsync(waiter, password);
            await userManager.CreateAsync(super, password);

            await userManager.AddToRoleAsync(manager, managerRole.Name);
            await userManager.AddToRoleAsync(waiter, waiterRole.Name);
            await userManager.AddToRolesAsync(super, new List<string> { managerRole.Name, waiterRole.Name });
        }
    }
}
