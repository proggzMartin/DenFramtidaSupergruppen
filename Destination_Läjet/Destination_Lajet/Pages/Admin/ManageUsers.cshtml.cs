using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Destination_Lajet.Data;
using Destination_Lajet.Models;

namespace Destination_Lajet.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public readonly UserManager<User> _userManager;

        public ManageUsersModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<User> Users { get; set; }




        public async Task OnGetAsync(string id)
        {


            Users = await _context.User.ToListAsync();
            await _context.SaveChangesAsync();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            await _userManager.IsInRoleAsync(user, "Organizer");

            if (await _userManager.IsInRoleAsync(user, "Organizer"))
            {

                await _userManager.RemoveFromRoleAsync(user, "Organizer");
            }
            else
            {

                await _userManager.AddToRoleAsync(user, "Organizer");
            }


            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/ManageUsers");
        }
    }

}
