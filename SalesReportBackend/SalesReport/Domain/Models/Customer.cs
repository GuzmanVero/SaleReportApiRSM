namespace SalesReport.Domain.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
