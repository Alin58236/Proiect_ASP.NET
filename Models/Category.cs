namespace beerT.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProdusCategory>? ProdusCategories { get; set; }

    }
}
