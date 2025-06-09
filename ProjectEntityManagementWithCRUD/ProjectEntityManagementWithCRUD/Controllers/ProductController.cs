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
        public async Task<List<Products>> GetProducts()
        {
            return await productContext.Products.ToListAsync();
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



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await productContext.Products.FirstOrDefaultAsync(x => x.ProductCode == id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            productContext.Products.Remove(product);
            await productContext.SaveChangesAsync();
            return Ok("Product deleted");
        }

    }
}
