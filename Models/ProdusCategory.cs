namespace beerT.Models
{
    public class ProdusCategory
    {
        public int ID { get; set; }
        public int ProdusID { get; set; }
        public Produs Produs { get; set; }
        public int CategoryID { get; set; }
        public Category Category{ get; set; }
    }
}
