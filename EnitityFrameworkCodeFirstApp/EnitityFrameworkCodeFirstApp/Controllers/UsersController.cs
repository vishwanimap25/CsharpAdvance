using EnitityFrameworkCodeFirstApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnitityFrameworkCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DBcontextFile userdbcontext;

        public UsersController(DBcontextFile userdbcontext)
        {
            this.userdbcontext = userdbcontext;
        }


        //CRUD : Create Read Update Delete

        //HttpGet = Read
        [HttpGet]
        [Route ("GetUsers")]
        public List<Users> GetUsers()
        {
            return userdbcontext.Users.ToList();
        }

        //HttpGet = Read
        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userdbcontext.Users.Where(x => x.Id == id).FirstOrDefault();

        }

        //HttpPost = Create
        [HttpPost]
        [Route ("AddUsers")]
        public string AddUsers(Users users)
        {
            string Responce = string.Empty;
            userdbcontext.Users.Add(users);
            userdbcontext.SaveChanges();
            return "User Added";
        }


        //HttpPut = Update
        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUsers(Users users) 
        {
            userdbcontext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userdbcontext.SaveChanges();

            return "User Updated";

        }


        //HttpDelete = Delete
        [HttpDelete]
        [Route("UserDelete")]
        public string DeleteUsers(int id) 
        {
            Users users = userdbcontext.Users.Where(x => x.Id == id).FirstOrDefault();
            if(users != null)
            {
                userdbcontext.Users.Remove(users);
                userdbcontext.SaveChanges();
                return "User deleted";
            }
            else
            {
                return "user not found"; 
            }
        }

    }
}
