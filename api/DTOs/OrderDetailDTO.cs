namespace api.DTOs;

public class OrderDetailDTO
{
    public string? OrderId { get; set; }
    public string? ProductId { get; set; }
    public int Quantity { get; set; }
}