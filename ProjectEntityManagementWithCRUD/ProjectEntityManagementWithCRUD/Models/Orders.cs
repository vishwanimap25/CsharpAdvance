using System.ComponentModel.DataAnnotations;

namespace ProjectEntityManagementWithCRUD.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public string orderCategory { get; set; }

        public string ProductName { get; set; }

        public int OrderDateTime { get; set; }

        public int OrderStatus { get; set; } = 0;
    }
}
