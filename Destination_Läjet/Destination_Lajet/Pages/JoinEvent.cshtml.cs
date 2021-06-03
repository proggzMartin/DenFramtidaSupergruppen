using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Data;
using Destination_Lajet.Models;

namespace Destination_Lajet.Pages
{
    [Authorize]
    public class JoinEventModel : PageModel
    {
        private readonly LajetContext _context;
        private readonly UserManager<User> _userManager;

        public JoinEventModel(LajetContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public Ad Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Ad.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }


            return Page();
        }

        [BindProperty]
        public Ad MyEvent { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);
            //var user = await _context.User.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();
            Event = await _context.Ad.FirstOrDefaultAsync(m => m.Id == id);

            //Event.SpotsAvailable--;

            //user.JoinedEvents.Add(Event);

            await _context.SaveChangesAsync();
            return RedirectToPage("/MyEvents");

        }
    }
}
