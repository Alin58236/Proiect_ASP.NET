using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;
using System.Net;

namespace beerT.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public IndexModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProdusD = new ProdusData();

            ProdusD.Produse = await _context.Produs
            .Include(b => b.Distribuitor)
            .Include(b => b.ProdusCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.denumire)
            .ToListAsync();

            if (id != null)
            {
                ProdusID = id.Value;
                Produs produs = ProdusD.Produse
                .Where(i => i.ID == id.Value).Single();
                ProdusD.Categories = produs.ProdusCategories.Select(s => s.Category);
            }
        }

    }
}
