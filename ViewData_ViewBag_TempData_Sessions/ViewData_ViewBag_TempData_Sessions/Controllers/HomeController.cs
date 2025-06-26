using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewData_ViewBag_TempData_Sessions.Models;

namespace ViewData_ViewBag_TempData_Sessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoToHome()
        {
            ViewData["Message"] = "Welcome to Go Home";

            ViewBag.Message = "Hello from ViewBag"; 

            //HttpContext.Session.SetString("Username", "Vishwa");
            //HttpContext.Session.SetInt32("UserId", 101);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
