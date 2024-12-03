using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Role {get; set;}
    public ICollection<Order>? Orders { get; set; }
    public ICollection<WarehouseReceipt>? WarehouseReceipts { get; set; }
}