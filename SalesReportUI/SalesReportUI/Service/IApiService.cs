using Microsoft.AspNetCore.Mvc;
using SalesReportUI.Models;

namespace SalesReportUI.Service
{
    public interface IApiService
    {
        Task<List<SalesOrderDetails>> GetSalesOrderDetailsAsync();
        Task<List<SalesOrderDetails>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilter filter);
        Task<List<ProductCategory>> GetAllProductName();
        Task<List<SalesOHeader>> GetAllYears();
        Task<List<SalesPersonName>> GetAllSalesPersonName();
        Task<List<CustomerName>> GetAllCustomerName(); 
        Task<List<SalesPerson>> GetSalesPerson(); 
        Task<List<SalesPerson>> GetSalesPersonDetails([FromQuery] SalesFilter filter);
    }
}
