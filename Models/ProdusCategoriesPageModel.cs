using Microsoft.AspNetCore.Mvc.RazorPages;
using beerT.Data;

namespace beerT.Models
{
    public class ProdusCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(beerTContext context,
        Produs produs)
        {
            var allCategories = context.Category;
            var produsCategories = new HashSet<int>(
            produs.ProdusCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = produsCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateProdusCategories(beerTContext context,
        string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.ProdusCategories = new List<ProdusCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var produsCategories = new HashSet<int>
            (produsToUpdate.ProdusCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategories.Contains(cat.ID))
                    {
                        produsToUpdate.ProdusCategories.Add(
                        new ProdusCategory
                        {
                            ProdusID = produsToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (produsCategories.Contains(cat.ID))
                    {
                        ProdusCategory courseToRemove
                        = produsToUpdate
                        .ProdusCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

