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

namespace Destination_Lajet.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]

    public class AddEventModel : PageModel
    {
        private readonly LajetContext _context;
        private readonly UserManager<User> _userManager;
        public AddEventModel(LajetContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Advertisement Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                //Event.Organizer = user;
                _context.Add(Event);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Organizer/OrganizeEvent");
            }

            return Page();
        }
    }
}
