using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestionPanier.Models.ViewModel
{
    public class ProductEditVM : ProductCreateVM
    {
        [HiddenInput]  // obliger 3la input n'affiche pas de la partie de formulaire 
     public int Id { get; set; }

        public ProductEditVM()
        {
            
        }
        public ProductEditVM(Product p)
        {
            this.Id = p.Id;
            this.Libelle = p.Libelle;
            this.PU = p.PU;
        }
    }
    
}
