using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;
using ProjectEntityManagementWithCRUD.Models.DTO;

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
        
        //(1) Add new users
        [HttpPost("AddUsers")]
        public async Task<IActionResult> AddUsers(Users users)
        {
            await userContext.Users.AddAsync(users);
            await userContext.SaveChangesAsync();
            return Ok("User Added");
        }

        //(2) Get All users
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers(int pageNumber = 1, int pageSize = 10) 
        {
            if (pageNumber <= 0 || pageSize <= 0) 
            {
                return BadRequest("Page Number or Page Size must be greater than zero");
            }
            var totalCount = await userContext.Users.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount/pageSize);
            
            if(pageNumber > totalPages && totalPages > 0)
            {
                return NotFound("Page not found");
            }

            var users = await userContext.Users
                        .Skip((pageNumber - 1)*pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            var userReadDtos = userContext.Users.Select(u => new UserReadDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
            
            return Ok(userReadDtos);
        }

        //(3) Get the users by id.
        [HttpGet]
        [Route("GetUserByID")]
        public async Task<Users> GetUser(int id)
        {
            //return userContext.Users.Where(predicate: x => x.UserId == id).FirstOrDefault();
            return await userContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto updatedto)
        {
            var existinguser = await userContext.Users.FindAsync(id);
            if(existinguser == null)
            {
                return NotFound("User Not Found");
            }

            //for Password 
            if(!string.IsNullOrEmpty(updatedto.Password))
            {
                if(updatedto.Password != updatedto.ConfirmPassword)
                {
                    return BadRequest("Password do not match");
                }
                existinguser.Password = updatedto.Password;
            }

            //for Name and Email
            existinguser.Name = updatedto.Name;
            existinguser.Email = updatedto.Email;

            await userContext.SaveChangesAsync();

            return Ok("User Updated");
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
