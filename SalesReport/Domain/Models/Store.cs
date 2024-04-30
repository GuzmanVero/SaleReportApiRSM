namespace SalesReport.Domain.Models
{
    public class Store
    {
        public int BusinessEntityID { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
