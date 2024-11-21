using MagicVenteStore.Metier.Models;

namespace MagicVenteStore.Metier.MetierServices
{
    public interface IProduitsServiceAPI
    {
        Task<Produit> RechercherProduitDuJour();
        Task CreateProduit(Produit produit);

        Task<List<Produit>> GetProduits();

        Task DeleteProduit(int id);

    }
}
