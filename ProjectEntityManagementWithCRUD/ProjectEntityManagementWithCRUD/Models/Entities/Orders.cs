using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectEntityManagementWithCRUD.Models.Entities
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public string orderCategory { get; set; }

        public string ProductName { get; set; }



        //[DefaultValue(false)]
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;

    }
}
