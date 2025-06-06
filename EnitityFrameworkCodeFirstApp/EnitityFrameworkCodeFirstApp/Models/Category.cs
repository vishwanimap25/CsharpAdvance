using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class Category
    {
        [Key]
        public int Id{ get; set; }

        public string Name{ get; set; }


        public DbSet<Product> Products { get; set; }
    }
}
