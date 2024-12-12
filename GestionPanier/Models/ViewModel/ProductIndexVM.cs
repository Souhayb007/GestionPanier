using System.ComponentModel.DataAnnotations;

namespace GestionPanier.Models.ViewModel
{
    public class ProductIndexVM
    {
        [Display(Name = "#")]    
        public int Id { get; set; }

        [Display(Name = " libelle de Produit ")]
        public string Libelle { get; set; }

        [Display(Name = "Prix unitaire")]
        public float PU { get; set; }

        public ProductIndexVM()
        {

        }
        public ProductIndexVM(Product p)
        {
            this.Id = p.Id;
            this.Libelle = p.Libelle;
            this.PU = p.PU;
        }
    }
}
