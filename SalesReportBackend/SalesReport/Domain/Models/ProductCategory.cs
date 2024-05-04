namespace SalesReport.Domain.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }

    }
}
