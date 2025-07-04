using System.ComponentModel.DataAnnotations;

namespace AuthticationForMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string password { get; set; }
        public string Role {  get; set; }
    }
}
