using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Data;
using Destination_Lajet.Models;

namespace Destination_Lajet.Pages.Comp
{
    public class IndexModel : PageModel
    {
        private readonly Destination_Lajet.Data.LajetContext _context;

        public IndexModel(Destination_Lajet.Data.LajetContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
        }
    }
}
