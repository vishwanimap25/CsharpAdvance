using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class UserDBcontext : DbContext
    {
        public UserDBcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
