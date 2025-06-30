using AuthticationForMVC.Db_Context;
using AuthticationForMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthticationForMVC.Controllers
{
    public class AuthController1 : Controller
    {
        private readonly AppDbContext context;

        public AuthController1(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        //GET 
        [HttpGet]
        public IActionResult Register() => View();
        
        //register post
        [HttpPost]
        public IActionResult Register(string Name, string Password)
        {
            if (FakeUserStore.User.Any(u => u.Name == Name))
            {
                ViewBag.Error = "User Already Exist";
                return View();
            }

            FakeUserStore.User.Add(new User
            {
                Name = Name,
                password = Password,
                Role = "User"
            });
            return RedirectToAction("Login");
        }

        //login get
        [HttpGet]
        public IActionResult Login()=> View();

        //login post
        [HttpPost]
        public IActionResult

    }
}
