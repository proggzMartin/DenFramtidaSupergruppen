using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Data;
using Destination_Lajet.Models;

namespace Destination_Lajet.Pages.Organizer.Changes
{
    public class DetailsEventModel : PageModel
    {
        private readonly LajetContext _context;

        public DetailsEventModel(LajetContext context)
        {
            _context = context;
        }

        public Advertisement Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Advertisement.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
