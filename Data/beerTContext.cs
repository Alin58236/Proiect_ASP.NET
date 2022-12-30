using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using beerT.Models;

namespace beerT.Data
{
    public class beerTContext : DbContext
    {
        public beerTContext (DbContextOptions<beerTContext> options)
            : base(options)
        {
        }

        public DbSet<beerT.Models.Produs> Produs { get; set; } = default!;

        public DbSet<beerT.Models.Distribuitor> Distribuitor { get; set; }

        public DbSet<beerT.Models.Angajat> Angajat { get; set; }

        public DbSet<beerT.Models.Category> Category { get; set; }

        public DbSet<beerT.Models.Client> Client { get; set; }

        public DbSet<beerT.Models.Comanda> Comanda { get; set; }
    }
}
