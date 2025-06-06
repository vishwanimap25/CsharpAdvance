using Microsoft.AspNetCore.Mvc;

namespace EnitityFrameworkCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
