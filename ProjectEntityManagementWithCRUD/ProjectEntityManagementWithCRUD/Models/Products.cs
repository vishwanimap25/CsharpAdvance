using System.ComponentModel.DataAnnotations;

namespace ProjectEntityManagementWithCRUD.Models
{
    public class Products
    {
        [Key]
        public Guid ProductCode { get; set; } = Guid.NewGuid();

        public int Price { get; set; }

        public string ProductName { get; set; }

        
    }
}
