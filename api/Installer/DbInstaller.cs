using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Installer;

public static class DbInstaller
{
    public static void InstallDb(this ModelBuilder builder)
    {
        builder.Entity<OrderDetail>()
            .HasKey(rd => new { rd.OrderId, rd.ProductId });

        builder.Entity<OrderDetail>()
            .HasOne(rd => rd.Order)
            .WithMany(r => r.OrderDetails)
            .HasForeignKey(rd => rd.OrderId);
        
        builder.Entity<WarehouseReceiptDetail>()
            .HasKey(rd => new { rd.WarehouseReceiptId, rd.ProductId });

        builder.Entity<WarehouseReceiptDetail>()
            .HasOne(rd => rd.WarehouseReceipt)
            .WithMany(r => r.WarehouseReceiptDetails)
            .HasForeignKey(rd => rd.WarehouseReceiptId);
        
        builder.Entity<ProductDetail>()
            .HasKey(rd => new { rd.Id, rd.ProductId });

    }
}