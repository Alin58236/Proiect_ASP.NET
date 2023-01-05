using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace beerT.Pages.Comenzi
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
            var produsList = _context.Produs
            .Select(x => new
            {
                x.ID,
                ProdusFullName = x.denumire + " - " +
            x.pret + " RON"
            }) ;

            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            ViewData["ProdusID"] = new SelectList(produsList, "ID", "ProdusFullName");
            
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }
        


        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comanda.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
