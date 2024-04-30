namespace SalesReport.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public int ProductSubcategoryID { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
