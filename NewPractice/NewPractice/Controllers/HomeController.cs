using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NewPractice.Model;

using NewPractice.Services;
using Microsoft.AspNetCore.Mvc;


namespace NewPractice.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICollectionss _coll;

        public HomeController(ICollectionss coll)
        {
            _coll = coll;
        }



        [HttpPost("AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUser(User user)
        {
            var userss = await _coll.AddUpdateUser(user);
            if(user == null)
            {
                return BadRequest("The user can't be added");
            }

           return Ok(userss);
        }



        [HttpPost("AddUpdateProduc")]
        public async Task<IActionResult> AddUpdateProduct(Product product)
        {
            var result = await _coll.AddUpdateProduct(product);
            if (product == null)
            {
                return BadRequest("The user can't be added");
            }
            return Ok(result);
        }



        [HttpPost("AddUpdateCategory")]
        public async Task<IActionResult> AddUpdateCategory(Category category)
        {
            var result = await _coll.AddUpdateCategory(category);
            if (category == null)
            {
                return BadRequest("The user can't be added");
            }
            return Ok(result);
        }




        [HttpPost("AddUpdateOrders")]
        public async Task<IActionResult> AddUpdateOrders(Orders orders)
        {
            var result = await _coll.AddUpdateOrders(orders);
            if (orders == null)
            {
                return BadRequest("The user can't be added");
            }
            return Ok(result);
        }
    }
}
