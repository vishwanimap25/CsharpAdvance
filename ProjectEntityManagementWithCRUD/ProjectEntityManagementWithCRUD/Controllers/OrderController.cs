using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DBContextFile orderContext;
        public OrderController(DBContextFile orderContext)
        {
            this.orderContext = orderContext;
        }


        [HttpPost]
        [Route("AddOrder")]
        public async  Task<string> AddOrder(Orders orders)
        {
            await orderContext.Orders.AddAsync(orders);
            await orderContext.SaveChangesAsync();
            return "Order Added";
        }


        [HttpGet]
        [Route("GetOrder")]
        public async Task<List<Orders>> GetOrder()
        {
            return await orderContext.Orders.ToListAsync();
        }


        [HttpGet]
        [Route("GetOrderById")]
        public async Task<Orders> GetOrderById(int id)
        {
            return await orderContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);    
            
        }


        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<string> UpdateOrder(Orders orders)
        {
            orderContext.Orders.Update(orders);
            await orderContext.SaveChangesAsync();
            return "order updated";

        }


        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            Orders orders =  await orderContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
            if (orders != null) 
            { 
                orderContext.Orders.Remove(orders);
                await orderContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound("order not found");
            }
        }
    }
}
