namespace SalesReport.Domain.interfaces
{
    using SalesReport.Application.Dtos;
    using SalesReport.Domain.Models;

    public interface ISalesODetailRepository
    {
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync();
    }
}
