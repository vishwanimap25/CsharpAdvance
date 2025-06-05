using System.ComponentModel.DataAnnotations;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public int MobileNo { get; set; }


    }
}
