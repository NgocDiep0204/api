using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Product
{
    [Key]
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string BrandId { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public byte[]? ProductImage { get; set; }
    public string? Ram { get; set; }
    public string? Color { get; set; }
    public string? ScreenSize { get; set; }
    public int Quantity { get; set; }
    public string? OperatingSystem {get; set;}
    public string? Rom { get; set; }
    public string? HardWare { get; set; }
    public string? Battery { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; }
    public ICollection<WarehouseReceiptDetail>? WarehouseReceiptDetails { get; set; }
    public ProductDetail? ProductDetail { get; set; }
}