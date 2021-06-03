using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Models;
using System.Threading.Tasks;

namespace Destination_Lajet.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Advertisement> Event { get; set; }
        public DbSet<User> User { get; set; }

        public async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            //await roleManager.CreateAsync(new IdentityRole("Attendee"));
            //await roleManager.CreateAsync(new IdentityRole("Admin"));
            //await roleManager.CreateAsync(new IdentityRole("Organizer"));

            //User admin = new User()
            //{
            //    UserName = "admin",
            //    Email = "admin@gmail.com",
            //    EmailConfirmed = true
            //};

            //await userManager.CreateAsync(admin, "Passw0rd!");
            //await userManager.AddToRoleAsync(admin, "Admin");

            /* 
             User organizer = new User()
             {
                 UserName = "organizer",
                 Email = "organizer@gmail.com",
             };

             await userManager.CreateAsync(organizer, "Passw0rd!");
             await userManager.AddToRoleAsync(organizer, "Organizer");
             */

            //Advertisement[] Event = new Advertisement[]
            //{
            //    new Advertisement() { Title="TheBestEventEver", Text="Event", Place="Halmstad", Address="Stockvägen 12", Date=DateTime.Now, SpotsAvailable=440, },
            //    new Advertisement() { Title="StarGazing", Text="Stjärnkådning", Place="Halmstad", Address="Wall Street 1", Date=DateTime.Now, SpotsAvailable=144, },
            //    new Advertisement() { Title="VolleybollMatch", Text="Volleyboll", Place="Dalarna", Address="ELmano road 1", Date=DateTime.Now, SpotsAvailable=255, },
            //    new Advertisement() { Title="Armbrytning", Text="Styrketräning", Place="Laholm", Address="LaholmLaholmsvägen 21", Date=DateTime.Now, SpotsAvailable=100, },
            //    new Advertisement() { Title="The2ndBestEventEver", Text="Festival", Place="Hässleholm", Address="Festivalvägen 1", Date=DateTime.Now, SpotsAvailable=422, }
            //};
            //await AddRangeAsync(Event);

            await SaveChangesAsync();
        }
    }

}
