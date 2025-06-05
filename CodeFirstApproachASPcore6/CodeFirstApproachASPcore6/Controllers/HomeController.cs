using System.Diagnostics;
using CodeFirstApproachASPcore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachASPcore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBcontext studentDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBcontext studentDB)
        {
            this.studentDB = studentDB;
        }

        public async  Task<IActionResult> Index()
        {
            var stdData = studentDB.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid) 
             {
                await studentDB.Students.AddAsync(std);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var stdData = studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(stdData);
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
