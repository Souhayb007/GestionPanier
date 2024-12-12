using GestionPanier.Filters;
using GestionPanier.Models;
using GestionPanier.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace GestionPanier.Controllers
{
    public class ProductController : Controller
    {
        Mycontext db;
        public ProductController(Mycontext db)
        {
            this.db = db;
        }
        [IsAdmin]
        public IActionResult Index()
        {
            List<ProductIndexVM> produits = db.Products.Select(p =>new ProductIndexVM(p)).ToList();
            return View(produits);
        }
        [HttpGet]
        [IsAdmin]
        public IActionResult Create()
        {
            return View();
        } 
         [HttpPost]
        [IsAdmin]
        public IActionResult Create(ProductCreateVM vm)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(new Product (vm));
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        [IsAdmin]
        public IActionResult Delete(int id)
        {
            Product p = db.Products.Where(p => p.Id == id).FirstOrDefault();
            if(id!=null) 
            { 
                db.Products.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
      
       
        [IsAdmin]
        public IActionResult Update(int id)
        {
           Product p = db.Products.Where(p => p.Id ==id).FirstOrDefault();
            if (id != null)
            {
                ProductEditVM mv = new ProductEditVM(p);
                return View(mv);
            }
            return RedirectToAction("Index");
        }
        [IsAdmin]
        [HttpPost]
        public IActionResult Update(ProductEditVM mv)
        {
            Product p = db.Products.Where(p => p.Id ==mv.Id).FirstOrDefault();
            if (p != null)
            {
               p.Libelle= mv.Libelle;
                p.PU=mv.PU;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(mv);
        }
        public IActionResult Catalogue()
        {
            List<ProductIndexVM> produits = db.Products.Select(p => new List<ProductIndexVM>(p)).ToList();
            return View(produits);
        }

        public IActionResult AddToPanier(int id)
        { //serialisation de tableau bach trado Json et pour afficher le panier khasni ndir la desirialisation
          //   string output = JsonConvert.SerializeObject(..);  // kif ma kan le tableau la situation dyalo yraj3o chaine de caractere 
          //    object obj = JsonConvert.DeserializeObject<object>(chaine);   // le contraire  la chaine de caractere se forme d'un object

            List<LignePanier> lignes;
            if (HttpContext.Session.GetString("Panier") == null) //table khawi
            {
              lignes = new List<LignePanier>();  //instanciation d'un nouveau table
            } else
            {
                 lignes = JsonConvert.DeserializeObject<List<LignePanier>>(HttpContext.Session.GetString("Panier")); 
               
            }

            /*   LignePanier p = new LignePanier();
               p.ProduitId = id;
               p.Qte = 1;
               lignes.Add(p);*/
            bool temoin = false;
            foreach (LignePanier item in lignes)
            {
              if(item.ProduitId == id)
                {
                    item.Qte++; 
                    temoin = true;
                }   
            }
            if(temoin== false) 
            {
                LignePanier p = new LignePanier();
                p.ProduitId = id;
                p.Qte = 1;
                lignes.Add(p);
            }
            HttpContext.Session.SetString("Panier", JsonConvert.SerializeObject(lignes));
            return RedirectToAction("Catalogue");
        }
    }
}
