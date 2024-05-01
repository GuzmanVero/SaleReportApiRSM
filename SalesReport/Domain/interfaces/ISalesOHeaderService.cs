using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ISalesOHeaderService
    {
        Task<List<SalesOHeaderDto>> GetAllYears();
    }
}
