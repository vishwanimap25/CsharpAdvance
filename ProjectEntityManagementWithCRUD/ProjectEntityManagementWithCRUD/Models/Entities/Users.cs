using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace ProjectEntityManagementWithCRUD.Models.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

      
        public string Email { get; set; }


        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;



        //navigation property
        public ICollection<Orders> Orders { get; set; } 


        
    }
}
