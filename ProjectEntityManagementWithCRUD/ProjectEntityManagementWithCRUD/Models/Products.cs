using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ProjectEntityManagementWithCRUD.Models
{
    public class Products
    {
        [Key]
        public Guid ProductCode { get; set; } = Guid.NewGuid();

        public int Price { get; set; }

        public string ProductName { get; set; }


        //[DefaultValue(false)]
        public int IsDeleted { get; set; } = 0;


    }
}
