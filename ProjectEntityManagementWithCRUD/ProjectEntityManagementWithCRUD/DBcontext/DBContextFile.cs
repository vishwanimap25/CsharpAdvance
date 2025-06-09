using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.Models;

namespace ProjectEntityManagementWithCRUD.DBcontext
{
    public class DBContextFile : DbContext
    {
        public DBContextFile(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}
