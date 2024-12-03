using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using System.IO; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var allproducts = await _context.Products
                                        .Include(c => c.Brand)
                                        .ToListAsync();
            return Ok(allproducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductDTO productDTO)
        {
            if (productDTO.ProductImage == null)
                return BadRequest("Image is required.");

            using var memoryStream = new MemoryStream();
            await productDTO.ProductImage.CopyToAsync(memoryStream);

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = productDTO.BrandId,
                ProductName = productDTO.ProductName,
                ProductDescription = productDTO.ProductDescription,
                ProductPrice = productDTO.ProductPrice,
                ProductImage =memoryStream.ToArray(), // Lưu dữ liệu ảnh dưới dạng byte[]
                Rom = productDTO.Rom,
                Ram = productDTO.Ram,
                Color = productDTO.Color,
                ScreenSize = productDTO.ScreenSize,
                Quantity = productDTO.Quantity,
                OperatingSystem = productDTO.OperatingSystem,
                HardWare = productDTO.HardWare,
                Battery = productDTO.Battery,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Product added successfully",  product.ProductId });
        }
        
    }
}
