using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;
using ProjectEntityManagementWithCRUD.Models.DTO;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly DBContextFile _context;
        public OrderItemController(DBContextFile context)
        {
            _context = context;
        }

        // (1) Add Order Item
        [HttpPost]
        public async Task<IActionResult> AddOrderItem(OrderItemCreateDto dto)
        {
            var orderItem = new OrderItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                OrderId = 1 // Example, set this properly
            };

            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return Ok("Order item added");
        }

        // (2) Get all order items
        [HttpGet]
        public async Task<ActionResult<List<OrderItemReadDto>>> GetAllOrderItems()
        {
            var items = await _context.OrderItems.Include(x => x.Products).ToListAsync();

            var result = items.Select(x => new OrderItemReadDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Products.Name,
                ProductPrice = x.Products.Price,
                Quantity = x.Quantity
            }).ToList();

            return Ok(result);
        }

        // (3) Get order item by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemReadDto>> GetOrderItemById(int id)
        {
            var item = await _context.OrderItems
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null) return NotFound();

            var dto = new OrderItemReadDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Products.Name,
                ProductPrice = item.Products.Price,
                Quantity = item.Quantity
            };

            return Ok(dto);
        }

        // (4) Delete Order Item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var item = await _context.OrderItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Order item deleted");
        }
    }
}
