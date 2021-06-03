using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Data;
using Destination_Lajet.Models;

namespace Destination_Lajet.Pages.Organizer.Changes
{
    [Authorize(Roles = "Organizer")]
    public class DeleteEventModel : PageModel
    {
        private readonly LajetContext _context;

        public DeleteEventModel(LajetContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Ad.FindAsync(id);

            if (Event != null)
            {
                _context.Ad.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Organizer/OrganizeEvent");
        }
    }
}