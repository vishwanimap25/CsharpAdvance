using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace ProjectEntityManagementWithCRUD.Models.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        
        public string UserName { get; set; }

        //[Column(TypeName = "number(10)")]
      
        public int MobileNumber { get; set; }


        public string Address { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;



        public ICollection<Orders> Orders { get; set; } 

        public ICollection<Categories> Categories { get; set; }

        
    }
}
