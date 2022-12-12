using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;

namespace beerT.Pages.Distribuitori
{
    public class DetailsModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public DetailsModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

      public Distribuitor Distribuitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }

            var distribuitor = await _context.Distribuitor.FirstOrDefaultAsync(m => m.ID == id);
            if (distribuitor == null)
            {
                return NotFound();
            }
            else 
            {
                Distribuitor = distribuitor;
            }
            return Page();
        }
    }
}
