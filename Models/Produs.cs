using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace beerT.Models
{
    public class Produs
    {
       
        public int ID { get; set; }
        [Display(Name = "Produse Denumire")]
        public string denumire { get; set; }


        [Column(TypeName = "decimal(6, 2)")]
        public decimal pret { get; set; }

        public int? DistribuitorID { get; set; }

        public Distribuitor? Distribuitor { get; set; }

        public ICollection<ProdusCategory>? ProdusCategories { get; set; }

    }
}
