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
    public class DetailsModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public DetailsModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

      public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .Include(c => c.Client)
                .Include(c => c.Produs)
                
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
    }
}
