using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesOHeaderRepository
    {
        Task<List<SalesOHeaderDto>> GetAllYears();
    }
}
