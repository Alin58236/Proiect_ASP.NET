using beerT.Models;
using System.Security.Policy;

namespace beerT.Models.ViewModels
{
    public class DistribuitorIndexData
    {
        public IEnumerable<Distribuitor> Distribuitori { get; set; }
        public IEnumerable<Produs> Produse { get; set; }

    }
}
