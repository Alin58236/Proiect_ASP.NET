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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace beerT.Pages.Produse
{
    [Authorize(Roles = "Admin")]

    public class EditModel : ProdusCategoriesPageModel
    {
        private readonly beerT.Data.beerTContext _context;
        public EditModel(beerT.Data.beerTContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Produs Produs { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            Produs = await _context.Produs
            .Include(b => b.Distribuitor)
            .Include(b => b.ProdusCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Produs == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 
            PopulateAssignedCategoryData(_context, Produs);
            
            
            ViewData["DistribuitorID"] = new SelectList(_context.Distribuitor, "ID","DistribuitorName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var produsToUpdate = await _context.Produs
            .Include(i => i.Distribuitor)
            .Include(i => i.ProdusCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (produsToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Produs>(
            produsToUpdate,
            "Book",
            i => i.denumire,
            i => i.pret, i => i.DistribuitorID))
            {
                UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
            PopulateAssignedCategoryData(_context, produsToUpdate);
            return Page();
        }
    }
}
