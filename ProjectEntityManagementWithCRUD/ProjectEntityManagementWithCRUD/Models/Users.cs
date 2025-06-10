using System.ComponentModel.DataAnnotations;



namespace ProjectEntityManagementWithCRUD.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; } 

        public string UserName { get; set; }

        //[Column(TypeName = "number(10)")]
      
        public int MobileNumber { get; set; }


        public string Address { get; set; }

      
        public int IsDeleted { get; set; } = 1;



        public ICollection<Orders> Orders { get; set; } 

        public ICollection<Categories> Categories { get; set; }

        
    }
}
