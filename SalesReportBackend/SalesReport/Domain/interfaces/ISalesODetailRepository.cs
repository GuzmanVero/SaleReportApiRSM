namespace SalesReport.Domain.interfaces
{
    using Microsoft.AspNetCore.Mvc;
    using SalesReport.Application.Dtos;
    using SalesReport.Domain.Models;

    public interface ISalesODetailRepository
    {
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync();
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByYear(int year);
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilterDto filter);
    }
}
