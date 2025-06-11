using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace ProjectEntityManagementWithCRUD.Models
{
    public class Products
    {
        [Key]
        public Guid ProductCode { get; set; } = Guid.NewGuid();

        public int Price { get; set; }

        public string ProductName { get; set; }


        //[DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;


    }
}
