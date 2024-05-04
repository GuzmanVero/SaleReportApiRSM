namespace SalesReport.Application.Dtos
{
    public class SalesFilterDto
    {
        public int? Year { get; set; }
        public string? productCategoryName { get; set; }
        public string? Customer { get; set;}
        public string? SalesPersonName { get; set; }
    }
}
