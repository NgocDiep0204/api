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
            var orderExists = _context.OrderDetails.FirstOrDefault( f => f.OrderId == orderDetail.OrderId && f.ProductId == orderDetail.ProductId);
            if (orderExists != null) return StatusCode(StatusCodes.Status409Conflict);
            var product = _context.Products.SingleOrDefault(f => f.ProductId == orderDetail.ProductId);
            
            if (product == null || product.Quantity < 0 ) return StatusCode(StatusCodes.Status404NotFound);
            
            if (orderDetail.Quantity > product.Quantity) return StatusCode(StatusCodes.Status400BadRequest);
            
            var newCartDetail = new OrderDetail
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
            };
            await _context.OrderDetails.AddAsync(newCartDetail);
            return await _context.SaveChangesAsync()  > 0 ?  StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartDetail(OrderDetailDTO orderDetail)
        {
            var quantityProduct = _context.Products.FirstOrDefault(f => f.ProductId == orderDetail.ProductId);
            
            var existCartDetail = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderDetail.OrderId && x.ProductId == orderDetail.ProductId);
            if (existCartDetail == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            if (quantityProduct.Quantity < orderDetail.Quantity)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "ko du");
            }

            existCartDetail.Quantity = orderDetail.Quantity;

            return await _context.SaveChangesAsync() > 0 
                ? StatusCode(StatusCodes.Status200OK) 
                : StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCartDetail(string cartId)
        {
            var allCartDetails = await _context.OrderDetails
                .Where(f => f.OrderId == cartId)
                .Select(od => new
                {
                    od.OrderId,
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
            return await _context.SaveChangesAsync()  > 0 ?  StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
   
   
}
