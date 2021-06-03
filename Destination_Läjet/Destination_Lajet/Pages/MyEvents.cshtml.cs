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
    public class MyEventsModel : PageModel
    {
        private readonly LajetContext _context;
        private readonly UserManager<User> _userManager;

        public MyEventsModel(LajetContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Advertisement> Event { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();

            Event = user.JoinedEvents;


        }
    }
}
