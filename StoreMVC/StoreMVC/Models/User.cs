using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(100)]
        public string Name{ get; set; }
        [MaxLength(100)]
        public string  Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(5)]
        public string UserPlan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
