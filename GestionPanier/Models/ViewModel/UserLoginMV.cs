using System.ComponentModel.DataAnnotations;

namespace GestionPanier.Models.ViewModel
{
    public class UserLoginMV
    {
        [Required(ErrorMessage = "login est obliger")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "le password obliger il faut superieur a 6 caractere")]
        public string Password { get; set; }
      
    }
}
