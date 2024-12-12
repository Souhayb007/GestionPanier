using Microsoft.EntityFrameworkCore;

namespace GestionPanier.Models
{
    public class Mycontext : DbContext
    {
        public  DbSet<User> users { get; set; }
        public  DbSet<Product> Products { get; set; }
        public Mycontext(DbContextOptions<Mycontext> opt) : base(opt) //MyContext constructeur yakhod parametre (dbContextOption<Mcontext type genirique> opt): base c'est une classe mere
        {
            
        }

    }
}
