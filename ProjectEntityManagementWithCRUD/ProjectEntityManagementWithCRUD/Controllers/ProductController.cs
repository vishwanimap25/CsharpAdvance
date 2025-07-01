using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;
using ProjectEntityManagementWithCRUD.Models.DTO;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DBContextFile productContext;
        public ProductController(DBContextFile productContext)
        {
            this.productContext = productContext;
        }
 

        //(1) Add Product
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDto dto)
        {
            var user = await productContext.Products.FindAsync(dto.UserId);

            if(user == null) { return NotFound("User not found"); }

            var product = new Products
            {
                Name = dto.Name,
                Price = dto.Price,
                UserId = dto.UserId,
                CategoryId = dto.CategoryId,
            };

            await productContext.Products.AddAsync(product);
            await productContext.SaveChangesAsync();
            return Ok("Product added");

        }

        //(2) Get all products
        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductReadDto>>> GetProducts(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and size must be greater than zero");
            }

            var totalCount = await productContext.Products
                .Where(p => !p.IsDeleted)
                .CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            if (pageNumber > totalPages && totalPages > 0)
            {
                return NotFound("Page not found");
            }

            var products = await productContext.Products
                .Where(p => !p.IsDeleted) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productdto = products.Select(u => new ProductReadDto
            {
                Name = u.Name,
                Price = u.Price,
                CategoryId = u.CategoryId
            }).ToList();

            return Ok(productdto);
        }

        //(3) Get one product by id
        [HttpGet("{UserId}")]
        public async Task<ActionResult<ProductReadDto>> GetProductByID(int UserId)
        {
            var product = await productContext.Products
                .Where(p => p.UserId == UserId)
                .ToListAsync();

            if(product == null || product.Count == 0)
            {
                return NotFound("No product found for this user");
            }

            return Ok(product);
        }

        //(4) Update Product
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductCreateDto products)
        {
            var existingProduct = await productContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound("User Not Found");
            }
            existingProduct.Name = products.Name;
            existingProduct.Price = products.Price;
            existingProduct.CategoryId = products.CategoryId;
            await productContext.SaveChangesAsync();
            return Ok("Product updated");
        }


        //(5) Soft Delete Products
        [HttpPatch("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var product = await productContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            if (product.IsDeleted)
            {
                return BadRequest("Product is already deleted.");
            }

            product.IsDeleted = true;
            await productContext.SaveChangesAsync();

            return Ok("Product soft deleted successfully.");
        }




        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(Guid id)
        //{
        //    var product = await productContext.Products.FirstOrDefaultAsync(x => x.ProductCode == id);
        //    if (product == null)
        //    {
        //        return NotFound("Product not found");
        //    }

        //    productContext.Products.Remove(product);
        //    await productContext.SaveChangesAsync();
        //    return Ok("Product deleted");
        //}

    }
}
