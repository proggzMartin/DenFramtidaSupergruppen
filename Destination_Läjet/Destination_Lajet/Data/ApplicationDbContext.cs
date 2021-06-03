using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destination_Lajet.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }

        public async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            await roleManager.CreateAsync(new IdentityRole("Attendee"));
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Organizer"));


            User admin = new User()
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, "Passw0rd!");
            await userManager.AddToRoleAsync(admin, "Admin");

            /* 
             User organizer = new User()
             {
                 UserName = "organizer",
                 Email = "organizer@gmail.com",
             };

             await userManager.CreateAsync(organizer, "Passw0rd!");
             await userManager.AddToRoleAsync(organizer, "Organizer");
             */

            Event[] Event = new Event[]
            {
                new Event() { Title="TheBestEventEver", Description="Event", Place="Halmstad", Address="Stockvägen 12", Date=DateTime.Now, SpotsAvailable=440, },
                new Event() { Title="StarGazing", Description="Stjärnkådning", Place="Halmstad", Address="Wall Street 1", Date=DateTime.Now, SpotsAvailable=144, },
                new Event() { Title="VolleybollMatch", Description="Volleyboll", Place="Dalarna", Address="ELmano road 1", Date=DateTime.Now, SpotsAvailable=255, },
                new Event() { Title="Armbrytning", Description="Styrketräning", Place="Laholm", Address="LaholmLaholmsvägen 21", Date=DateTime.Now, SpotsAvailable=100, },
                new Event() { Title="The2ndBestEventEver", Description="Festival", Place="Hässleholm", Address="Festivalvägen 1", Date=DateTime.Now, SpotsAvailable=422, }
            };



            await AddRangeAsync(Event);

            await SaveChangesAsync();
        }
    }

}
