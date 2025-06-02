using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproachASPcore6.Models
{
    public class Student
    {
        [Key]
        public int Id { set; get; }

        [Column("StudentName" , TypeName ="varchar(100)")]
        public String Name { get; set; }

        [Column("StudentGender", TypeName = "varchar(10)")]
        public String Gender { get; set; }

        public int Age { get; set; }

        public int Standard { get; set; }
    }
}
