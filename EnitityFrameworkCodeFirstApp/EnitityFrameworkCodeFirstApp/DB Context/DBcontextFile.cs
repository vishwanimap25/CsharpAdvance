using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class DBcontextFile : DbContext
    {
        public DBcontextFile(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
