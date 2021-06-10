using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Destination_Lajet.Models;
using Destination_Lajet.Interfaces;

namespace Destination_Lajet.Pages.Comp
{
    public class CreateModel : PageModel
    {
        private readonly IDbService db;

        public CreateModel(IDbService db)
        {
            this.db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.AddNewCompany(Company);

            return RedirectToPage("./Index");
        }
    }
}
