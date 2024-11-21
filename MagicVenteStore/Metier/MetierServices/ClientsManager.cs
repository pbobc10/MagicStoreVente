using MagicVenteStore.Data;
using MagicVenteStore.Metier.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVenteStore.Metier.MetierServices
{
    public class ClientsManager : IClientsServiceAPI
    {
        private readonly MagicVenteStoreContext _context;

        public ClientsManager(MagicVenteStoreContext context)
        {
           _context = context;
        }

        public async Task<Client> RechercherClientParPseudo(string pseudo, string motDePasse)
        {

            if (pseudo == null || motDePasse == null)
                return null;

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Pseudo == pseudo && c.MotDePasse == motDePasse);

            if (client == null)
                throw new Exception("not found");
                
            return client;
        }
    }
}
