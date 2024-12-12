using GestionPanier.Models.ViewModel;

namespace GestionPanier.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public float PU { get; set; }

        public Product()
        {
            
        }
        public Product(ProductCreateVM uvm)
        {
            this.Libelle = uvm.Libelle;
            this.PU = uvm.PU;
        }

    }
}
