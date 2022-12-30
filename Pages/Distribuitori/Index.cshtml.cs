using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using beerT.Data;
using beerT.Models;
using beerT.Models.ViewModels;
using System.Security.Policy;

namespace beerT.Pages.Distribuitori
{
    public class IndexModel : PageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public IndexModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        public IList<Distribuitor> Distribuitor { get;set; } = default!;
        public DistribuitorIndexData DistribuitorData { get; set; }
        public int DistribuitorID { get; set; }
        public int ProdusID { get; set; }

        public async Task OnGetAsync(int? id, int? produsID)
        {
            DistribuitorData = new DistribuitorIndexData();
            DistribuitorData.Distribuitori = await _context.Distribuitor
            .Include(i => i.Produse)
            .OrderBy(i => i.DistribuitorName)
            .ToListAsync();
            if (id != null)
            {
                DistribuitorID = id.Value;
                Distribuitor distribuitor = DistribuitorData.Distribuitori
                .Where(i => i.ID == id.Value).Single();
                DistribuitorData.Produse = distribuitor.Produse;
            }
        }
    }
}

