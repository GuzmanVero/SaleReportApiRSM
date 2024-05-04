using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesOHeaderRepository
    {
        Task<List<SalesOHeaderDto>> GetAllYears();
        Task<List<SalesPersonDto>> GetSalesPersonDetails([FromQuery] SalesPersonfilterDto filter); 
        Task<List<SalesPersonDto>> GetSalesPerson();
    }
}
