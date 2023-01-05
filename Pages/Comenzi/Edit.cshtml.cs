using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;

namespace beerT.Pages.Comenzi
{
    public class EditModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public EditModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda =  await _context.Comanda.FirstOrDefaultAsync(m => m.ID == id);
            if (comanda == null)
            {
                return NotFound();
            }

            var produsList = _context.Produs
                .Select(x => new
                {
                    x.ID,
                    ProdusFullName = x.denumire + " - " + x.pret + " RON "
                });

           //nu stiu daca trebe comentat sau nu ---> Comanda = comanda;
            ViewData["ProdusID"] = new SelectList(produsList, "ID", "ProdusFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(Comanda.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComandaExists(int id)
        {
          return _context.Comanda.Any(e => e.ID == id);
        }
    }
}
