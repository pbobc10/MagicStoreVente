using MagicVenteStore.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using MagicVenteStore.Metier.Models;

namespace MagicVenteStore.Metier.MetierServices
{
    public class ProduitsManager : IProduitsServiceAPI
    {
        private readonly MagicVenteStoreContext _magicVenteStoreContext;


        public ProduitsManager(MagicVenteStoreContext magicVenteStoreContext)
        {
            _magicVenteStoreContext = magicVenteStoreContext;

        }

        public async Task CreateProduit(Produit produit)
        {
            _magicVenteStoreContext.Produits.Add(produit);

            try
            {
                await _magicVenteStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitExists(produit.Id))
                {
                    throw new NotImplementedException();
                }
            }

        }

        public async Task<List<Produit>> GetProduits()
        {
            return await _magicVenteStoreContext.Produits.ToListAsync();

        }

        public async Task<Produit> RechercherProduitDuJour()
        {
            try
            {
                if (_magicVenteStoreContext.Produits == null)
                    return null;

                return await _magicVenteStoreContext.Produits.AsNoTracking().SingleAsync(c => c.EstDuJour);
            }
            catch (DbException)
            {
                throw;
            }
        }


        public async Task DeleteProduit(int id)
        {
            // Find the product by id
            var produit = await _magicVenteStoreContext.Produits.FindAsync(id);

            // If no product found, throw an exception or handle accordingly
            if (produit == null)
            {
                throw new KeyNotFoundException("Produit not found");
            }

            // Remove the product from the database
            _magicVenteStoreContext.Produits.Remove(produit);

            // Save changes to persist the deletion
            await _magicVenteStoreContext.SaveChangesAsync();
        }


        private bool ProduitExists(int id)
        {
            return (_magicVenteStoreContext.Produits?.Any(p => p.Id == id)).GetValueOrDefault();
        }

    }
}
