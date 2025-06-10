using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectEntityManagementWithCRUD.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public string orderCategory { get; set; }

        public string ProductName { get; set; }

        public DateTime OrderDateTime { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

    }
}
