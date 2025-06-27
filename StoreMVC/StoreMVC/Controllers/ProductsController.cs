using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using StoreMVC.Models;
using StoreMVC.Models.Dto;
using StoreMVC.Services;

namespace StoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDBcontext _productContext;
        private readonly IWebHostEnvironment envirnoment;

        public ProductsController(ApplicationDBcontext productContext, IWebHostEnvironment envirnoment)
        {
            _productContext = productContext;
            this.envirnoment = envirnoment;
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

        [HttpPost]
        public IActionResult Create(ProductDto productdto)
        {
            if(productdto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile" , "The image is required");
            }
            if(!ModelState.IsValid)
            {
                return View(productdto); 
            }

            //save image file
            string newFileName = DateTime.Now.ToString("yyyyddMMHHmmssfff");
            newFileName += Path.GetExtension(productdto.ImageFile!.FileName);

            string ImageFullPath = envirnoment.WebRootPath + "/IMAGES/" + newFileName;
            using (var stream = System.IO.File.Create(ImageFullPath))
            {
                productdto.ImageFile.CopyTo(stream);
            }

            //save the new product in the database
            Product product = new Product()
            {
                Name = productdto.Name,
                Brand = productdto.Brand,
                Category = productdto.Category,
                Price = productdto.Price,
                Description = productdto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            _productContext.Product.Add(product);
            _productContext.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Edit(int id)
        {
            var product = _productContext.Product.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            //create productdto from product 
            var productDto = new ProductDto()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
            };

            ViewData["productid"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");

            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = _productContext.Product.Find(id);

            if(product == null)
            {
                return RedirectToAction("Index", "Products");
            }
            if (!ModelState.IsValid)
            {
                ViewData["productid"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");
                return View(productDto);
            }

            //update the image file if, we have new image file
            string NewFileName = product.ImageFileName;
            if(productDto.ImageFile != null)
            {
                NewFileName = DateTime.Now.ToString("yyyyddMMHHmmssfff");
                NewFileName += Path.GetExtension(productDto.ImageFile.FileName);

                string ImageFullPath = envirnoment.WebRootPath + "/IMAGES/" + NewFileName;  
                using (var stream = System.IO.File.Create(ImageFullPath))
                {
                    productDto.ImageFile.CopyTo(stream);
                }
            }

            //delete the old images
            string oldImageFullPath = envirnoment.WebRootPath + "/IMAGES/" + product.ImageFileName;
            System.IO.File.Delete(oldImageFullPath);


            //update the product in the database
            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.ImageFileName = NewFileName;


            _productContext.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Delete(int id)
        {
            var product = _productContext.Product.Find(id);
            if(product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            string imagepath = envirnoment.WebRootPath + "/IMAGES/" + product.ImageFileName;
            System.IO.File.Delete(imagepath);

            _productContext.Product.Remove(product);
            _productContext.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}
