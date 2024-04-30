using System;

namespace SalesReport.Domain.Models
{
    public class Employee
    {
        public int BusinessEntityID { get; set; }
        public virtual Person Person { get; set; }
    }
}
