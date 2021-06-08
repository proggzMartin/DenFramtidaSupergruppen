using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Destination_Lajet.Data;
using Destination_Lajet.Models;
using Destination_Lajet.Interfaces;

namespace Destination_Lajet.Pages.Comp
{
    public class DeleteModel : PageModel
    {
        private readonly IDbService db;

        public DeleteModel(IDbService db)
        {
            this.db = db;
        }

        [BindProperty]
        public Company Company { get; set; }

        public IActionResult OnGet(int id)
        {
            Company = db.GetCompany(id);

            if (Company == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Company = db.GetCompany(id);

            if (Company != null)
                db.RemoveCompany(Company.Id);

            return RedirectToPage("./Index");
        }
    }
}
