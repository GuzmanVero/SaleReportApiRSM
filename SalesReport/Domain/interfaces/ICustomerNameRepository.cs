using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ICustomerNameRepository
    {
        Task<List<customerNameDto>> GetAllCustomerName();
    }
}
