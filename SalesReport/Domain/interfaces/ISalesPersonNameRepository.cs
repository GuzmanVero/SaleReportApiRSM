using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesPersonNameRepository
    {
        Task<List<SalesPersonNameDto>> GetAllSalesPersonName();
    }
}
