using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.Models;

namespace ProjectEntityManagementWithCRUD.DBcontext
{
    public class DBContextFile : DbContext
    {
        public DBContextFile(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public object OrderItem { get; internal set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
             .HasMany(u => u.Products)
             .WithOne(p => p.Users)
             .HasForeignKey(p => p.UserId);
        }

    }
}
