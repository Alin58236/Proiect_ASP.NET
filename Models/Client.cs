using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace beerT.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Comanda>? Comenzi { get; set; }
    }
}
