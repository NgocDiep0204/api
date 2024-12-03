using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class OrderDetail
{
    [Key]
    public required string OrderId { get; set; }
    public required string ProductId { get; set; }
    public required int Quantity { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}