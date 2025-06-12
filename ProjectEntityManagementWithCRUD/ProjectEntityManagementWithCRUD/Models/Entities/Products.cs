using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace ProjectEntityManagementWithCRUD.Models.Entities
{
    public class Products
    {
        [Key]
        public int Id{ get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }


        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;


        //foregin key
        public int CategoryId { get; set; }
        public Categories Categories { get; set; } = null;

        //navigation property
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
