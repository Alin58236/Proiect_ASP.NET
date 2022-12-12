using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;

namespace beerT.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public IndexModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Angajat != null)
            {
                Angajat = await _context.Angajat.ToListAsync();
            }
        }
    }
}
