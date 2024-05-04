using System.Net;

namespace SalesReport.Domain.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int SalesPersonID { get; set; }
        public int CustomerID { get; set; }
        public int ShipToAddressID { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public decimal TotalDue { get; set; }

    }
}
