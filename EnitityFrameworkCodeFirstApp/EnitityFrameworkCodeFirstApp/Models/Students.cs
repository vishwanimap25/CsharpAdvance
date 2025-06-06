using System.ComponentModel.DataAnnotations;

namespace EnitityFrameworkCodeFirstApp.Models
{
    public class Students
    {
        [Key]
        public int RollNO { get; set; }

        public string StdName { get; set; }


        public int MobileNumber { get; set; }


        public int Dob { get; set; }
    }
}
