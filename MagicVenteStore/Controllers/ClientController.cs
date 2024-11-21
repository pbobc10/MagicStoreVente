using MagicVenteStore.Metier.MetierServices;
using MagicVenteStore.Metier.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVenteStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsServiceAPI _clientsServiceAPI;

    public ClientController(IClientsServiceAPI context)
    {
            _clientsServiceAPI = context;
    }

    // POST: api/Auth/Login
    [HttpPost("login")]
    public async Task<IActionResult> Login( Client request)
    {
        if (request == null || string.IsNullOrEmpty(request.Pseudo) || string.IsNullOrEmpty(request.MotDePasse))
        {
            return BadRequest("Pseudo et mot de passe sont obligatoires.");
        }

            var utilisateur = await _clientsServiceAPI.RechercherClientParPseudo(request.Pseudo, request.MotDePasse);

        if (utilisateur == null)
        {
            return Unauthorized("Pseudo ou mot de passe incorrect.");
        }

        // Simulez la création d'un token JWT ou renvoyez les informations utilisateur
        return Ok(new
        {
            Numero = utilisateur.Numero,
            Nom = utilisateur.Nom,
            Prenom = utilisateur.Prenom,
            Message = "Login réussi."
        });
    }
    }
}
