//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TaskofSurpricseReview.Db_context;
//using TaskofSurpricseReview.Model;

//namespace TaskofSurpricseReview.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : Controller
//    {
//        private readonly AppDbContext context;

//        public ProductController(AppDbContext context)
//        {
//            this.context = context;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> AddProduct(Product product, int id)
//        {
//            var newadded = await context.product.FirstOrDefaultAsync(x => x.productid == id);
//            if (newadded != null)
//            {
//                newadded.productname = product.productname;
//                await context.SaveChangesAsync();
//            }
//            else
//            {
//                await context.product.AddAsync(product);
//            }
//            await context.SaveChangesAsync();
//            return Ok("added and updated");
//        }


        

//    }
//}
