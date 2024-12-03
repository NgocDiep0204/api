namespace api.Models;

public class Order
{
    public required string OrderId { get; set; }
    public required string UserId { get; set; }
    public required string OrderTypeId { get; set; }
    public DateTime OrderDate { get; set; }
    public int? Status { get; set; }
    public decimal? Total { get; set; }
    
    public OrderType? OrderType { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; }
}