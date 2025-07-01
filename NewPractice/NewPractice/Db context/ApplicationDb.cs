using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewPractice.Model;

namespace NewPractice.Db_context
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDb()
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}
