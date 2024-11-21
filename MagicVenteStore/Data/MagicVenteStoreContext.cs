using MagicVenteStore.Metier.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVenteStore.Data
{
    public class MagicVenteStoreContext : DbContext
    {
        public MagicVenteStoreContext(DbContextOptions<MagicVenteStoreContext> options) : base(options) { }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<Client> Clients { get; set; }

        

    }
}
