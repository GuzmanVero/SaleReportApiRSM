namespace SalesReportUI.Models
{
    public class SalesReport
    {
        public List<SalesOrderDetails> SalesOrderDetails { get; set; }
        public List<SalesOrderDetails> list { get; set; }
        public List<int> Years { get; set; }
        public List<string> CategoryName { get; set; }
        public int SelectedYear { get; set; }
        public string SelectedCategory { get; set; }
        public string employeeName { get; set; }
        public string customerName { get; set; }
        public List<SalesPerson> listVendor { get; set; }
        public List<SalesPerson> SalesPerson { get; set; }
    }
}
