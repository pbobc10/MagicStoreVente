using MagicVenteStore.Metier.MetierServices;
using MagicVenteStore.Metier.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicVenteStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitsServiceAPI _produitsManager;
        public ProduitController( IProduitsServiceAPI produitsManager)
        {
            _produitsManager = produitsManager;
        }

        // GET: api/<ProduitController>
        [HttpGet]
        public async Task<IEnumerable<Produit>> Get()
        {
            return await _produitsManager.GetProduits();
        }

        // GET api/<ProduitController>/5
        [HttpGet("{id}")]
        public Task<Produit> Get(bool id)
        {
            return _produitsManager.RechercherProduitDuJour();
        }

        // POST api/<ProduitController>
        [HttpPost]
        public void Post([FromBody] Produit value)
        {
            _produitsManager.CreateProduit(value);
        }

        // PUT api/<ProduitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProduitController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produitsManager.DeleteProduit(id);
                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Produit not found.");
            }
        }
    }
}
