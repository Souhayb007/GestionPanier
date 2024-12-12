using System.ComponentModel.DataAnnotations;

namespace GestionPanier.Models.ViewModel
{
    public class UsersRegisterVM
    {
        [Required(ErrorMessage ="le Nom est obliger")]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Required(ErrorMessage ="login est obliger")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="le password obliger il faut superieur a 6 caractere")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="obliger la comnfiramtion sera equiv a la pass")]
        public string ConfirmPassword { get; set; }
  
      
    }
}
