using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskofSurpricseReview.Db_context;
using TaskofSurpricseReview.Model;

namespace TaskofSurpricseReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category, int id)
        {
            var newadded = await context.category.FirstOrDefaultAsync(x => x.categoryid == id);
            if (newadded != null)
            {
                newadded.Name = category.Name;
                await context.SaveChangesAsync();

            }
            else
            {
                await context.category.AddAsync(category);
            }
            await context.SaveChangesAsync();
            return Ok("added and updated");
        }
    }

}
