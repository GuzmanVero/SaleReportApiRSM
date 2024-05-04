using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesPersonNameService
    {
        Task<List<SalesPersonNameDto>> GetAllSalesPersonName();
    }
}
