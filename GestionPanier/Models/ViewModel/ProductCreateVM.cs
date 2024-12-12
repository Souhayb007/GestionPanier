using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace GestionPanier.Models.ViewModel
{
    public class ProductCreateVM
    {
   
        public string Libelle { get; set; }
        [Display(Name ="Pu")]
        public float PU { get; set; }
    }
}
