namespace SalesReport.Domain.Models
{
    public class ProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public string? Name { get; set; }
        public int ProductCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
