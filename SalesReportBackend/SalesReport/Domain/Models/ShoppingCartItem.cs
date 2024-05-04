namespace SalesReport.Domain.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
