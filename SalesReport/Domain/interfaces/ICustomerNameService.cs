using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface ICustomerNameService
    {
        Task<List<customerNameDto>> GetAllCustomerName();
    }
}
