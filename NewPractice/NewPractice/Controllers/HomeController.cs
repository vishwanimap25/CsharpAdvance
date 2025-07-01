using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPractice.Db_context;
using NewPractice.Model;

namespace NewPractice.Controllers
{

    [Route("api[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ApplicationDb context;

        public HomeController(ApplicationDb context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(int id, User user)
        {
            var newadd = await context.User.FindAsync(id);
            if (newadd == null)
            {
                newadd.Name= user.Name;
                await context.User.AddAsync(newadd);
            }
            else
            {
                context.User.Update(user);
                await context.SaveChangesAsync();   
            }
                return Ok();

        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(int id, Product product)
        {
            var newadd = await context.Product.FindAsync(id);
            if (newadd == null)
            {
                newadd.Name = product.Name;
                await context.User.AddAsync(newadd);
            }
            else
            {
                context.User.Update(product);
                await context.SaveChangesAsync();
            }
            await context.SaveChangesAsync();
            return Ok();

        }


        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddUser(int id, User user)
        {
            var newadd = await context.User.FindAsync(id);
            if (newadd == null)
            {
                newadd.Name = user.Name;
                await context.User.AddAsync(newadd);
            }
            else
            {
                context.User.Update(user);
                await context.SaveChangesAsync();
            }
            return Ok();

        }


        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddUser(int id, User user)
        {
            var newadd = await context.User.FindAsync(id);
            if (newadd == null)
            {
                newadd.Name = user.Name;
                await context.User.AddAsync(newadd);
            }
            else
            {
                context.User.Update(user);
                await context.SaveChangesAsync();
            }
            return Ok();

        }
    }
}
