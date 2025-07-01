using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskofSurpricseReview.Db_context;
using TaskofSurpricseReview.Model;

namespace TaskofSurpricseReview.One_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }




        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer, int id)
        {
            var newadded = await context.customer.FindAsync(customer.CustomerId);
            if (newadded != null)
            {
                newadded.Email = customer.Email;
                newadded.Name = customer.Name;
                //await context.SaveChangesAsync();
            }
            else
            {
                await context.AddAsync(customer);
            }

                await context.SaveChangesAsync();

            return Ok("saved Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id, Customer customer)
        {
            var getuser = await context.customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            
            if(customer == null)
            {
                return NotFound($"customer id with {id} not found");
            }

            return Ok(getuser);
        }
    }
}
