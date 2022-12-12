using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using beerT.Data;

using System.Security.Policy;
using beerT.Migrations;
using ProdusCategory = beerT.Models.ProdusCategory;
using Microsoft.EntityFrameworkCore;
using beerT.Models;

namespace beerT.Pages.Produse
{
    public class CreateModel : ProdusCategoriesPageModel
    {
        private readonly beerT.Data.beerTContext _context;

        public CreateModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["DistribuitorID"] = new SelectList(_context.Distribuitor, "ID", "DistribuitorName");

            var produs = new Produs();

            produs.ProdusCategories = new List<ProdusCategory>();

            PopulateAssignedCategoryData(_context, produs);


            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }


        
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.ProdusCategories = new List<ProdusCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProdusCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProdus.ProdusCategories.Add(catToAdd);
                }
            }
            Produs.ProdusCategories = newProdus.ProdusCategories;
            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newProdus);
            return Page();


        }

    }
}