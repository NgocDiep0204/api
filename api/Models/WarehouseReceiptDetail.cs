using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class WarehouseReceiptDetail
{
    [Key]
    public required string WarehouseReceiptId { get; set; }
    public required string ProductId { get; set; }
    public int Quantity { get; set; }
    public WarehouseReceipt? WarehouseReceipt { get; set; }
    public Product? Product { get; set; }
}