namespace beerT.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        public string DistribuitorName { get; set; }
        public ICollection<Produs>? Produse { get; set; } //navigation property


    }
}
