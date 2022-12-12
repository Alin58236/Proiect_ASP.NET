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

namespace beerT.Pages.Distribuitori
{
    public class EditModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public EditModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Distribuitor Distribuitor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }

            var distribuitor =  await _context.Distribuitor.FirstOrDefaultAsync(m => m.ID == id);
            if (distribuitor == null)
            {
                return NotFound();
            }
            Distribuitor = distribuitor;
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

            _context.Attach(Distribuitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistribuitorExists(Distribuitor.ID))
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

        private bool DistribuitorExists(int id)
        {
          return _context.Distribuitor.Any(e => e.ID == id);
        }
    }
}
