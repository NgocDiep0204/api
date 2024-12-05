using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;

        public ProductController(ApplicationDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var allproducts = await _context.Products
                                        .Include(c => c.Brand)
                                        .ToListAsync();
            return Ok(allproducts);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetail(string ProductId)
        {
            var productById = await _context.Products.Include(c => c.Brand).SingleOrDefaultAsync(c => c.ProductId == ProductId);
            return Ok(productById);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest("foodimagDTo is null.");
            string imgPath = null;
            if (productDTO.ProductImage != null)
            {
                
                var uploadResult = await _imageService.AddImageAsync(productDTO.ProductImage);
                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    imgPath = uploadResult.SecureUrl.AbsoluteUri;
                }
                else
                {
                    return StatusCode((int)uploadResult.StatusCode, "Image upload failed.");
                }
            }
            var product = new Product
            {   
                ProductId = Guid.NewGuid().ToString(),
                BrandId = productDTO.BrandId,
                ProductName = productDTO.ProductName,
                ProductDescription = productDTO.ProductDescription,
                ProductPrice = productDTO.ProductPrice,
                ProductImage = imgPath,
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
