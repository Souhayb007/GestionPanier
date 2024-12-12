using GestionPanier.Models;
using GestionPanier.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GestionPanier.Controllers
{
    public class UsersController : Controller
    {
        Mycontext db;
        public UsersController(Mycontext db )
        {
            this.db = db;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inscription(UsersRegisterVM vm)
        {
            if(ModelState.IsValid)
            {
                int count = db.users.Where(us=>us.Login == vm.Login).Count();
                if(count == 0) 
                {
                    // Mapper Object Classe 1------><-- Object Classe 2
                    // Operateur implicit d'affectation Classe 1 = Classe 2
                    // Constructeur de transfert new Classe1(Classe2)
                    User u = new User(vm);
                    db.users.Add(u);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Nom", u.Nom);
                    HttpContext.Session.SetString("Prenom", u.Prenom);
                    HttpContext.Session.SetString("Role", u.Role);
                    return RedirectToAction("Index", "Products");
                }
                ModelState.AddModelError("Login", "Login existe deja");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginMV vm)
        {
            User u = db.users.Where(us => us.Login == vm.Login && us.Password == vm.Password).First() ;
            if (u != null)
            {
                u.DateDerniereConnexion= DateTime.Now;
                db.SaveChanges();
                HttpContext.Session.SetString("Nom", u.Nom);
                HttpContext.Session.SetString("Prenom", u.Prenom);
                HttpContext.Session.SetString("Role", u.Role);
                 return RedirectToAction("Index", "Product",u);
            
            }
            ModelState.AddModelError("Login", "Login ou mot de passe eroner");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  
            return View("Login");
        }
    }
}
