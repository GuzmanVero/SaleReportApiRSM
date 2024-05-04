namespace SalesReport.Domain.Models
{
    public class SalesPerson
    {
        public int BusinessEntityID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
