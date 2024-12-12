using GestionPanier.Models.ViewModel;
using System.Reflection;

namespace GestionPanier.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime DateInscription { get; set; }
        public DateTime DateDerniereConnexion { get; set; }
        public User() { }


        public User(UsersRegisterVM uvm) { 
        
        this.Nom = uvm.Nom;
        this.Prenom = uvm.Prenom;
        this.Login = uvm.Login;
        this.Password = uvm.Password;
            this.DateInscription = DateTime.Now;
            this.DateDerniereConnexion = DateTime.Now;
            this.Role = "Client";
        }
    }
}
