using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Models;
using System.Threading.Tasks;

namespace Destination_Lajet.Data
{
    public class LajetContext : IdentityDbContext<User>
    {
        public LajetContext(DbContextOptions<LajetContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }

        public DbSet<Ad> Ad { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<User> User { get; set; }

        public async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            await roleManager.CreateAsync(new IdentityRole("defaultUser"));
            //await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            await Roles.ToListAsync();

            User admin = new User()
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };


            User users = new User()
            {
                UserName = "testuser@mail.com",
                NormalizedUserName = "TESTUSER@MAIL.COM",
                Email = "testuser@mail.com",
                NormalizedEmail = "TESTUSER@MAIL.COM",
                EmailConfirmed = true,
            };
            User users2 = new User()
            {
                UserName = "testuser2@mail.com",
                NormalizedUserName = "TEST2@MAIL.COM",
                Email = "testuser2@mail.com",
                NormalizedEmail = "TESTUSER2@MAIL.COM",
                EmailConfirmed = true,
            };

            Ad ads = new Ad()
            {
                Title = "Soda",
                Category = "drinks",
                Business = "soda_store",
                Text = "cheap soda",
                Claims = 100
            };

            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.CreateAsync(users, "Test123!");
            await userManager.CreateAsync(users2, "Test123!");

            await userManager.AddToRoleAsync(admin, "Admin");
            await userManager.AddToRoleAsync(users, "Admin");
            await userManager.AddToRoleAsync(users2, "defaultUser");

            Add(ads);
            await SaveChangesAsync();



        }

    }

}
