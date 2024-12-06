using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = _context.Orders.FirstOrDefault(o => o.UserId == userId);
            return Ok(new {cart = cart});
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO order)
        {
            var cartExist = _context.Orders.Any(o => o.UserId == order.UserId);
            if (cartExist) return BadRequest();
            var newoder = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                UserId = order.UserId,
                OrderTypeId = "1",
                OrderDate = DateTime.Now,
            };
            _context.Orders.Add(newoder);
            return await _context.SaveChangesAsync()  > 0 ?  StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status500InternalServerError);

        }
        
    }
}
