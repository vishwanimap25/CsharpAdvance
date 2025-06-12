using System.ComponentModel.DataAnnotations;

namespace ProjectEntityManagementWithCRUD.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }


        //foregin key and navigation
        public int OrderId { get; set; }
        public Orders Orders { get; set; } = null;

        public int ProductId { get; set; }
        public Products Products { get; set; } = null;


        public int Quantity { get; set; } //Reference Navigation
    }
}
