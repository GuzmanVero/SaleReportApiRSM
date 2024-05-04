using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesOHeaderService
    {
        Task<List<SalesOHeaderDto>> GetAllYears();
        Task<List<SalesPersonDto>> GetSalesPersonDetails([FromQuery] SalesPersonfilterDto filter);
        Task<List<SalesPersonDto>> GetSalesPerson();
    }
}
