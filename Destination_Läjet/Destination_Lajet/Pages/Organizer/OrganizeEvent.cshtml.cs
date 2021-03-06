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
    public class OrganizeEventModel : PageModel
    {
        private readonly LajetContext _context;
        private readonly UserManager<User> _userManager;


        public OrganizeEventModel(LajetContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<Ad> Event { get; set; }
        public User user { get; set; }

        public async Task OnGetAsync()
        {
            var username = User.Identity.Name;
            //user = await _context.Users.Where(u => u.UserName == username).Include(h => h.HostedEvents).FirstOrDefaultAsync();
            //Event = user.HostedEvents.ToList();
        }
    }
}