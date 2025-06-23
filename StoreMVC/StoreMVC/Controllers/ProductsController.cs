using Microsoft.AspNetCore.Mvc;
using StoreMVC.Services;

namespace StoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDBcontext _productContext;
        public ProductsController(ApplicationDBcontext productContext)
        {
            _productContext = productContext; 
        }

        public IActionResult Index()
        {

            var products = _productContext.Product.OrderByDescending(x => x.Id).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
