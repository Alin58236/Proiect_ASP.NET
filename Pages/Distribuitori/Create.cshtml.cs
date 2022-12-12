using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using beerT.Data;
using beerT.Models;

namespace beerT.Pages.Distribuitori
{
    public class CreateModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public CreateModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Distribuitor Distribuitor { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Distribuitor.Add(Distribuitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
