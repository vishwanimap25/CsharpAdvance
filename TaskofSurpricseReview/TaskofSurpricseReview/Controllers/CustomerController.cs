using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskofSurpricseReview.Db_context;
using TaskofSurpricseReview.Model;

namespace TaskofSurpricseReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AppDbContext cusContext;

        public CustomerController(AppDbContext cusContext)
        {
            this.cusContext = cusContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddCustomers")]
        public async Task<ActionResult> AddCustomers(Customer customer, int id)
        {
            var newadded = await cusContext.customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            if(newadded != null)
            {
                newadded.Email = customer.Email;
                newadded.Name = customer.Name;
                await context.SaveChangesAsync();
            }
            else
            {
                await cusContext.customer.AddAsync(customer);
            }
            await cusContext.SaveChangesAsync();
            return Ok("added and updated");
        }
        
    }


}





