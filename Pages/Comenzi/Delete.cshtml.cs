using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;

namespace beerT.Pages.Comenzi
{
    public class DeleteModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public DeleteModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .Include(b => b.Client)
                .Include(b => b.Produs)
                .ThenInclude(b => b.Distribuitor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (comanda == null)
            {
                return NotFound();
            }
            else 
            {
                Comanda = comanda;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }
            var comanda = await _context.Comanda.FindAsync(id);

            if (comanda != null)
            {
                Comanda = comanda;
                _context.Comanda.Remove(Comanda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
