using MagicVenteStore.Metier.Models;

namespace MagicVenteStore.Metier.MetierServices
{
    public interface IClientsServiceAPI
    {
       Task<Client> RechercherClientParPseudo(string pseudo, string motDePasse);
    }
}
