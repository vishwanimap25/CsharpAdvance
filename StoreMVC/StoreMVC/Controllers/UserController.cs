using Microsoft.AspNetCore.Mvc;
using StoreMVC.Models;
using StoreMVC.Models.Dto;
using StoreMVC.Services;

namespace StoreMVC.Controllers
{
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


    }
}
