using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Brand
{
    [Key]
    public required int BrandId { get; set; }  // Primary Key
    public required string BrandName { get; set; }  // Tên thương hiệu
    public int? ParentBrandId { get; set; }  // Foreign Key trỏ đến thương hiệu mẹ (nullable)
    
    // Điều này tạo quan hệ đệ quy (Brand có thể có một thương hiệu mẹ)
    public virtual Brand ParentBrand { get; set; }  // Liên kết với thương hiệu mẹ
    public virtual ICollection<Brand> SubBrands { get; set; }  // Liên kết với các thương hiệu con
    
    // Constructor để khởi tạo danh sách các thương hiệu con
    public Brand()
    {
        SubBrands = new List<Brand>();
    }
    
    public ICollection<Product>? Products { get; set; }
}
