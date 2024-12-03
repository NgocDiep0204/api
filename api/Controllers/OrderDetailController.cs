using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartDetail(OrderDetailDTO orderDetail)
        {
            bool orderExists = _context.OrderDetails.Any(f => f.ProductId == orderDetail.ProductId);
            if (orderExists) return StatusCode(StatusCodes.Status500InternalServerError);
            bool isAvailable = _context.Products.Any(f => f.ProductId == orderDetail.ProductId && f.Quantity > 0);
            if (!isAvailable) return StatusCode(StatusCodes.Status409Conflict);
            var newCartDetail = new OrderDetail
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
            };
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDetail(OrderDetailDTO orderDetail)
        {
            if (!_context.OrderDetails.Any(f => f.ProductId == orderDetail.ProductId && f.Quantity > 0))
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
            var existCartDetail = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderDetail.OrderId && x.ProductId == orderDetail.ProductId);
            existCartDetail.Quantity = orderDetail.Quantity;
            return await _context.SaveChangesAsync()  > 0 ?  StatusCode(StatusCodes.Status201Created) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartDetail(string cartId)
        {
            var allCartDetails = _context.OrderDetails
                .Where(f => f.ProductId == cartId)
                .Select(od => new
                {
                    od.ProductId,
                    od.Product.ProductName,
                    od.Quantity,
                    od.Product.ProductPrice,
                    od.Product.ProductImage
                }).ToListAsync();
            return Ok(allCartDetails);
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteAllCartDetail(string orderId)
        {
            var orderDetails = _context.OrderDetails.Where(x => x.OrderId == orderId).ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            return await _context.SaveChangesAsync() > 0 
                ? StatusCode(StatusCodes.Status200OK) 
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCartDetails(string orderId, string productId)
        {
            var existOrderDetail = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);
            if(existOrderDetail == null) return StatusCode(StatusCodes.Status404NotFound);
            _context.OrderDetails.Remove(existOrderDetail);
            return await _context.SaveChangesAsync()  > 0 ?  StatusCode(StatusCodes.Status201Created) : StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
   
   
}
