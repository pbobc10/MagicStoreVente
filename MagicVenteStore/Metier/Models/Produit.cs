namespace MagicVenteStore.Metier.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public bool EstDuJour { get; set; } = false;
        public float Prix { get; set; }
        public int QuantiteEnStock { get; set; }

    }
}
