namespace SalesReport.Domain.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int OrderQty { get; set; }
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
        public virtual Product Product { get; set; }
    }
}
