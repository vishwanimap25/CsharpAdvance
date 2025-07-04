﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration configuration;
        public UserController(DBContextFile userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }


        //Register new users
        [HttpPost("Registration")]
        public async Task<ActionResult> RegisterUsers(UserRegisterDto registeruser)
        {
            var user = new Users
            {
                Name = registeruser.Name,
                Email = registeruser.Email,
                Password = registeruser.Password
            };
            await userContext.Users.AddAsync(user);
            await userContext.SaveChangesAsync();
            return Ok("User Added");
        }

        //(1) Login new users
        [HttpPost("Login")]
        public async Task<IActionResult> AddUsers(UserLoginDto logindto)
        {
            var user = await userContext.Users.FirstOrDefaultAsync(x => x.Email == logindto.Email  && x.Password == logindto.Password);
            if(user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub , configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Email", user.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { tokenValue = tokenValue, Users = user });
                //return Ok(user);
            }

            //await userContext.Users.AddAsync(users);
            //await userContext.SaveChangesAsync();
            //return Ok("User Added");
            return NoContent();
        }

        //(2) Get All users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and size must be greater than zero");
            }

            var totalCount = await userContext.Users.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            if (pageNumber > totalPages && totalPages > 0)
            {
                return NotFound("Page not found");
            }

            var users = await userContext.Users
                 .Where(u => !u.IsDeleted)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            var userDtos = users.Select(u => new UserReadDto
            {
                Id = u.UserId,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            //var pagedResult = new PagedResult<UserReadDto>
            //{
            //    TotalCount = totalCount,
            //    TotalPages = totalPages,
            //    CurrentPage = pageNumber,
            //    PageSize = pageSize,
            //    Items = userDtos
            //};

            return Ok(userDtos);
        }

        //(3) Get the users by id.
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var oneUser = await userContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (oneUser == null)
            {
                return NotFound("User not found");
            }

            var userDto = new UserReadDto
            {
                Id = oneUser.UserId,
                Name = oneUser.Name,
                Email = oneUser.Email
                // Map other properties as needed
            };

            return Ok(userDto);
        }



        //Update User info.
        [Authorize]
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


        //(5) for soft delete
        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            user.IsDeleted = true;
            await userContext.SaveChangesAsync();

            return Ok("User soft deleted");
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
