using SalesReport.Application.Dtos;
using SalesReport.Domain.Models;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesODetailService
    {
        Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync();
    }
}
