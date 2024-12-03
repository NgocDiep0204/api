namespace api.DTOs;

public class ProductDTO
{
    public string? ProductName { get; set; }
    public string? BrandId { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public IFormFile? ProductImage { get; set; }
    public string? Ram { get; set; }
    public string? Color { get; set; }
    public string? ScreenSize { get; set; }
    public int Quantity { get; set; }
    public string? OperatingSystem {get; set;}
    public string? Rom { get; set; }
    public string? HardWare { get; set; }
    public string? Battery { get; set; }
}