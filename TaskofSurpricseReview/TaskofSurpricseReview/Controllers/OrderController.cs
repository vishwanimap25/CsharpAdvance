using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskofSurpricseReview.Db_context;
using TaskofSurpricseReview.Model;

namespace TaskofSurpricseReview.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly AppDbContext context;

        public OrderController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(Orders orders, int id)
        {
            var newadded = await context.orders.FirstOrDefaultAsync(x => x.Id == id);
            if (newadded != null)
            {
                newadded.Name = orders.Name;
                await context.SaveChangesAsync();
            }
            else
            {
                await context.orders.AddAsync(orders);
            }
            await context.SaveChangesAsync();
            return Ok("customer added and updated");
        }

        [HttpGet("GetMaxOrder")]
        public async Task<ActionResult> GetMaxOrder(int id)
        {
            var newproduct = await context.orders.FirstOrDefaultAsync(x => x.productid == id);

            var neworder = await context.orders.MaxAsync<Orders>();

            return Ok(neworder);
        }
    }
}
