using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.Models.Entities;

namespace ProjectEntityManagementWithCRUD.DBcontext
{
    public class DBContextFile : DbContext
    {
        public DBContextFile(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Categories> Categories { get; set; }  // ✅ Correct placement

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Orders>()
                .Property(o => o.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Products>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Users>()
                .Property(u => u.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Categories>()
                .Property(c => c.IsDeleted)
                .HasDefaultValue(false);
        }

    }
}
