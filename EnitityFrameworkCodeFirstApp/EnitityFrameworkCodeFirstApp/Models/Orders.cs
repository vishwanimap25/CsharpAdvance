using System.ComponentModel.DataAnnotations;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }


        public int User_Id { get; set; }

        public int Order_Date { get; set; }


        public int Time { get; set; }

    }
}
