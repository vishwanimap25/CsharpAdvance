using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPractice.Db_context;
using NewPractice.Model;

namespace NewPractice.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class HomeController : Controller
    {
        private readonly ICollection coll;

        public HomeController(ICollection coll)
        {
            this.coll = coll;
        }



        [HttpPost("AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUSer()
        {
            var user = 
        }
    }
}
