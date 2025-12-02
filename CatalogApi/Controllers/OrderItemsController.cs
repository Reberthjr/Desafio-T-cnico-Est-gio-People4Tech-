using CatalogApi.Data;
using CatalogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems
                .Include(i => i.Product)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var item = await _context.OrderItems
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null) return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem item)
        {
            _context.OrderItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderItem), new { id = item.Id }, item);
        }
    }
}
