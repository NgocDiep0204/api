namespace api.Models;

public class WarehouseReceipt
{
    public required string WarehouseReceiptId { get; set; }
    public required string UserId { get; set; }
    public required DateTime DateTime { get; set; }
    public string? Status { get; set; }
    public decimal Total { get; set; }
    public ApplicationUser? User { get; set; }
    public ICollection<WarehouseReceiptDetail>? WarehouseReceiptDetails { get; set; }
}