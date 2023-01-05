using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace beerT.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ProdusID { get; set; }
        public Produs? Produs { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataRezervare { get; set; }

    }
}
