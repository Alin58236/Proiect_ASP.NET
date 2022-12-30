using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using beerT.Data;
using beerT.Models;
using Microsoft.EntityFrameworkCore;

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
            var produsLista = _context.Produs
            .Include(b => b.Distribuitor)
            .Select(x => new
             {
                 x.ID,
                 ProdusFullName = x.denumire + " - " + x.Distribuitor.DistribuitorName + " - " +
            x.pret
             });

            ViewData["ProdusID"] = new SelectList(produsLista, "ID",
           "ProdusFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID",
           "FullName");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
