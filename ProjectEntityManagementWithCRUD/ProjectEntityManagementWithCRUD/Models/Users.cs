using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectEntityManagementWithCRUD.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; } 

        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "number(10)")]
        [Required]
        public int MobileNumber { get; set; }


        public string Address { get; set; }


        public DbSet<Orders> Orders { get; set; } 

        public DbSet<Categories> Categories { get; set; }
    }
}
