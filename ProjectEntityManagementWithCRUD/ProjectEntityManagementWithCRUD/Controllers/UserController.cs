using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBContextFile userContext;
        public UserController(DBContextFile userContext)
        {
            this.userContext = userContext;
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<string> AddUsers(Users users)
        {
            await userContext.Users.AddAsync(users);
            await userContext.SaveChangesAsync();
            return "user added";
        }


        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<Users>> GetUsers(int pageNumber = 1, int pageSize = 10) 
        { 
            var totalCount = await userContext.Users.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount/pageSize);

            return await userContext.Users.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
            //return await userContext.Users.ToListAsync();
        }

        [HttpGet]
        [Route("GetUserByID")]
        public async Task<Users> GetUser(int id)
        {
            //return userContext.Users.Where(predicate: x => x.UserId == id).FirstOrDefault();
            return await userContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<string> UpdateUser(Users users)
        {
            userContext.Users.Update(users);
            await userContext.SaveChangesAsync();
            return "user updated";
        }


        [HttpPatch("{id}")]
        public async Task<string> DeleteUser(int id, Users users)
        {
            var user = await userContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                return "no user found";
            }
            else
            {
                users.IsDeleted = true;
            }
            await userContext.SaveChangesAsync();
            return "user deleted";
        }

        //[HttpDelete]
        //[Route("DeleteUser")]
        //public async Task<string> DeleteUser(int id)
        //{
        //    Users users = await userContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        //    if(users == null)
        //    {
        //        return "user not found";
        //    }
        //    else
        //    {
        //        userContext.Users.Remove(users);
        //        await userContext.SaveChangesAsync();
        //        return "user deleted";
        //    }
            
           
        //}
    }
}
