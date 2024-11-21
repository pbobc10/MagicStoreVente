using System.ComponentModel.DataAnnotations;

namespace MagicVenteStore.Metier.Models
{
    public class Client
    {
        [Key]
        public string Numero { get; set; } // Identifiant unique
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

    }
}
