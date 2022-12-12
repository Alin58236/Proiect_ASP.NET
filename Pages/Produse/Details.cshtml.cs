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

namespace beerT.Pages.Produse
{
    public class DetailsModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public DetailsModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

      public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs.FirstOrDefaultAsync(m => m.ID == id);
            if (produs == null)
            {
                return NotFound();
            }
            else 
            {
                Produs = produs;
                ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID",
"DistribuitorName");
            }
            return Page();
        }
    }
}
