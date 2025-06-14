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
        public async Task<List<Orders>> GetOrder(int pageNumber = 1, int pageSize = 10)
        {
            var totalCount = await orderContext.Orders.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            //var orderPerPage = await orderContext.Orders.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return await orderContext.Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            //return await orderContext.Orders.ToListAsync();
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


        [HttpPatch("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeleteOrder(int id)
        {
            var order = await orderContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            if (order.IsDeleted == true)
            {
                return BadRequest("Order already deleted");
            }
            else
            {
                order.IsDeleted = true;
            }

                
            await orderContext.SaveChangesAsync();

            return NoContent();
        }




        //[HttpDelete]
        //[Route("DeleteOrder")]
        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    Orders orders =  await orderContext.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        //    if (orders != null) 
        //    { 
        //        orderContext.Orders.Remove(orders);
        //        await orderContext.SaveChangesAsync();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound("order not found");
        //    }
        //}
    }
}
