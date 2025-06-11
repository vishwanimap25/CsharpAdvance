using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;

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

        [HttpPost]
        [Route("AddProduct")]
        public async Task<string> AddProduct(Products products)
        {
            await productContext.Products.AddAsync(products);
            await productContext.SaveChangesAsync();
            return "User added";

        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<object>> GetProducts(int pageNumber = 1, int pageSize = 10)
        {
            var query = productContext.Products
                .Where(p => !p.IsDeleted); // Exclude soft-deleted products

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Products = products
            });
        }


        [HttpGet]
        [Route("GetProductByID")]
        public async Task<IActionResult> GetProductByID(Guid id)
        {
            //return userContext.Products.Where(predicate: x => x.ProductCode == id).FirstOrDefault();
            var product = await productContext.Products.FirstOrDefaultAsync(x => x.ProductCode == id);
            if (product == null) return NotFound("Product not found");
            return Ok(product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<string> UpdateProduct(Products products)
        {
            productContext.Products.Update(products);
            await productContext.SaveChangesAsync();
            return "Product updated";
        }



        [HttpPatch("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeleteProduct(Guid id)
        {
            var product = await productContext.Products.FirstOrDefaultAsync(p => p.ProductCode == id);

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
