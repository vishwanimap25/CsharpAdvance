using EnitityFrameworkCodeFirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnitityFrameworkCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DBcontextFile OrderContext;
        public OrderController(DBcontextFile OrderContext)
        {
            this.OrderContext = OrderContext;
        }


        [HttpPost]
        [Route("PlaceOrders")]
        public Orders PlaceOrders()
        {
            return 
        }
        
    }
}
