using EnitityFrameworkCodeFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCodeFirstApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DBcontextFile productContext;
        public ProductController(DBcontextFile productContext)
        {
            this.productContext = productContext;
        }

        [HttpGet]
        [Route("GetProducts")]
       public List<Product> GetProducts()
        {
            return productContext.Product.ToList();
        }


        [HttpPost]
        [Route("AddProducts")]
        public string AddProducts(Product product)
        {
            string Responce = String.Empty;
            productContext.Product.Add(product);
            productContext.SaveChanges();
            return "Product Added";
        }


        [HttpGet("GetProductsid")]
        public Product GetProductsid(int id)
        {
            return productContext.Product.Where(x => x.Product_no == id).FirstOrDefault();
        }


        [HttpPut]
        [Route("UpdateProduct")]
        public string UpdateProducts(Product product) 
        {
            productContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            productContext.SaveChanges();
            return "product updated";
        }

        [HttpDelete]
        [Route("DeleteProducts")]
        public string DeleteProducts(int id)
        {
            var deleteProduct = productContext.Product.Where(x => x.Product_no == id).FirstOrDefault();
            if(deleteProduct != null)
            {
                productContext.Remove(deleteProduct);
                productContext.SaveChanges();
                return "product deleted";
            }
            return "product not found";
        }

    }
}

