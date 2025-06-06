using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class Product
    {
        [Key]
        public int Product_no { get; set; }

        [Column("Product_Name", TypeName = "varchar(10)")]
        [Required]
        public string Name { get; set; }


        [Column("Product_size", TypeName = "varchar(2)")]
        [Required]
        public int Size { get; set; }


        [Column("Product_Color", TypeName = "varchar(10)")]
        [Required]
        public string Colour { get; set; }
    }
}
