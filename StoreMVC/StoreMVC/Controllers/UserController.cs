using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMVC.Models;
using StoreMVC.Models.Dto;
using StoreMVC.Services;

namespace StoreMVC.Controllers
{
    //[Authorize(UserPlan)]
    public class UserController : Controller
    {
        private readonly ApplicationDBcontext _userContext;
        private readonly IWebHostEnvironment environment;

        public UserController(ApplicationDBcontext userContext, IWebHostEnvironment environment)
        {
            _userContext = userContext;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var users = _userContext.User.OrderBy(x => x.UserId).ToList();
            return View(users);
        }
        public IActionResult Adduser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adduser(UserCreateDto usercreatedto)
        {
            User user = new User()
            {
                Name = usercreatedto.Name,
                Email = usercreatedto.Email,
                Password = usercreatedto.Password,
                UserPlan = usercreatedto.UserPlan,
                CreatedAt = DateTime.Now,
            };

            if (!ModelState.IsValid)
            {
                return View(usercreatedto);
            }

            _userContext.User.Add(user);
            _userContext.SaveChanges();

            return RedirectToAction("Index", "User");


        }


        public IActionResult Delete(int id)
        {
            var user = _userContext.User.Find(id);
            if(user == null)
            {
                return RedirectToAction("Index", "User");
            }
            _userContext.User.Remove(user);
            _userContext.SaveChanges();

            return RedirectToAction("Index", "User");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //for login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userContext.User.
                FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if(user == null)
            {
                ViewBag.Error = "Invalid email or Password";
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.UserPlan, user.UserPlan),
                new Claim("UserId", user.UserId.ToString())
            };     

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }
        //for logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        //Access Denied
        public IActionResult AccessDenied()
        {
            return Content("Access Denied");
        }


    }
}
