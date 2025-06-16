using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityManagementWithCRUD.DBcontext;
using ProjectEntityManagementWithCRUD.Models;
using ProjectEntityManagementWithCRUD.Models.DTO;

namespace ProjectEntityManagementWithCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DBContextFile _context;
        public OrderController(DBContextFile context)
        {
            _context = context;
        }

        // (1) Create new order
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderCreateDto dto)
        {
            var order = new Orders
            {
                orderCategory = "SomeCategory", // You can map as needed
                ProductName = "SomeProduct",   // or make dynamic
                IsDeleted = false
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in dto.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderID,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
            return Ok("Order created");
        }

        // (2) Get all orders with pagination
        [HttpGet]
        public async Task<ActionResult<PagedResult<OrderReadDto>>> GetOrders(int pageNumber = 1, int pageSize = 10)
        {
            var totalCount = await _context.Orders.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            if (pageNumber > totalPages && totalPages > 0)
                return NotFound("Page not found");

            var orders = await _context.Orders
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var orderDtos = new List<OrderReadDto>();

            foreach (var order in orders)
            {
                var items = await _context.OrderItems
                    .Where(x => x.OrderId == order.OrderID)
                    .Include(x => x.Products)
                    .ToListAsync();

                var itemDtos = items.Select(x => new OrderItemReadDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Products.Name,
                    ProductPrice = x.Products.Price,
                    Quantity = x.Quantity
                }).ToList();

                var dto = new OrderReadDto
                {
                    Id = order.OrderID,
                    OrderDate = DateTime.Now, // You can update based on model
                    UserId = 0,               // Replace with real user id if needed
                    UserMail = "sample@mail.com",
                    OrderItems = itemDtos
                };

                orderDtos.Add(dto);
            }

            var result = new PagedResult<OrderReadDto>
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Items = orderDtos
            };

            return Ok(result);
        }

        // (3) Get order by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound("Order not found");

            var items = await _context.OrderItems
                .Where(x => x.OrderId == order.OrderID)
                .Include(x => x.Products)
                .ToListAsync();

            var itemDtos = items.Select(x => new OrderItemReadDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Products.Name,
                ProductPrice = x.Products.Price,
                Quantity = x.Quantity
            }).ToList();

            var dto = new OrderReadDto
            {
                Id = order.OrderID,
                OrderDate = DateTime.Now,
                UserId = 0,
                UserMail = "sample@mail.com",
                OrderItems = itemDtos
            };

            return Ok(dto);
        }

        // (4) Update Order
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Orders updatedOrder)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
                return NotFound("Order not found");

            existingOrder.orderCategory = updatedOrder.orderCategory;
            existingOrder.ProductName = updatedOrder.ProductName;

            await _context.SaveChangesAsync();
            return Ok("Order updated");
        }

        // (5) Soft delete
        [HttpPatch("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound("Order not found");

            if (order.IsDeleted)
                return BadRequest("Order already deleted");

            order.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Ok("Order deleted");
        }
    }
}
