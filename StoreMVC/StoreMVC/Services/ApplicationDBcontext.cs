using Microsoft.EntityFrameworkCore;
using StoreMVC.Models;

namespace StoreMVC.Services
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options) 
        {



        }


        public DbSet<Product> Product { get; set; }

        public DbSet<User> User { get; set; }
    }
}
