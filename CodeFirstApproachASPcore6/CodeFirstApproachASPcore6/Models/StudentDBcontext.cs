using Microsoft.EntityFrameworkCore;


namespace CodeFirstApproachASPcore6.Models
{
    public class StudentDBcontext : DbContext
    {
        public StudentDBcontext(DbContextOptions <StudentDBcontext >options) : base(options)
        {
            
        }


        public DbSet<Student> Students { get; set; }
    }
}
