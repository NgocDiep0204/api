namespace api.Models;

public class ProductDetail
{
    public int Id { get; set; }
    public required string ProductId { get; set; }
    public required string IMEI { get; set; }
    public string? Status {get; set;}
    
    public Product? Product { get; set; }
    
}