using EnitityFrameworkCodeFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DBcontextFile _StudentContext;
        public StudentController(DBcontextFile StudentContext) => _StudentContext = StudentContext;

        [HttpPost]
        [Route("AddStudent")]
        public string AddStudents(Students students)
        {
            string Responce = string.Empty;
            _StudentContext.Students.Add(students);
            _StudentContext.SaveChanges();
            return Responce;
        }

        [HttpGet]
        [Route("GetStudent")]
        public List<Students> GetStudents() => _StudentContext.Students.ToList();
        


        [HttpGet]
        [Route("GetStudentById")]
        public Students GetStudentById(int id)
        {
            return _StudentContext.Students.Where(x => x.RollNO == id).FirstOrDefault();
        }


        [HttpPut]
        [Route("UpdateStudent")]
        public string UpdateStudent(Students students)
        {
            _StudentContext.Entry(students).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _StudentContext.SaveChanges();
            return "student updated";
        }


        [HttpDelete]
        [Route("DeleteStudent")]
        public string DeleteStudent(int id)
        {
            //var deleteStu =  _StudentContext.Students.Where(x => x.RollNO == id).FirstOrDefault();
            //or
            Students deleteStu = _StudentContext.Students.Where(x => x.RollNO == id).FirstOrDefault();
            if (deleteStu == null)
            {
                return "student not found";
            }
            else
            {
                _StudentContext.Students.Remove(deleteStu);
                _StudentContext.SaveChanges();
                return "student deleted";
            }
        }
        
        
    }
}
