using Microsoft.EntityFrameworkCore;
using TaskofSurpricseReview.Model;

namespace TaskofSurpricseReview.Db_context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }


        public DbSet<Customer> customer { get; set; }
        public DbSet<Orders> orders{ get; set; }
        public DbSet<Category> category{ get; set; }
        public DbSet<Product> product { get; set; }
    }
}
