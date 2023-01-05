using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace beerT.Models
{
    public class Client
    {
        public int ID { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]

        public string? Prenume { get; set; }


        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }
        [StringLength(70)]
        public string? Adresa { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]

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
