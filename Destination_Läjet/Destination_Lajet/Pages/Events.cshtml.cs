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

namespace Destination_Lajet.Pages
{
    public class EventsModel : PageModel
    {
        private readonly Destination_Lajet.Data.LajetContext _context;

        public EventsModel(Destination_Lajet.Data.LajetContext context)
        {
            _context = context;
        }

        public IList<Ad> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Ad.ToListAsync();
        }
    }
}
