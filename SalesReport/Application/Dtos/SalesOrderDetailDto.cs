namespace SalesReport.Application.Dtos
{
    public class SalesOrderDetailDto
    {
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string SalesPersonName { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        //public int OrderQty { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
    }
}
