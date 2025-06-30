using AuthticationForMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthticationForMVC.Db_Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }


        public DbSet<User> User{ get; set; }
    }
}
