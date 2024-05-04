using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.Models;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesODetailService
    {
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync();
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByYear(int year);
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilterDto filter);
    }
}

