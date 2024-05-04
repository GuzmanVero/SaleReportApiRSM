using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using SalesReport.Infrastructure.Repositories;

namespace SalesReport.Application.Service
{
    public class CustomerNameService : ICustomerNameService
    {
        private readonly ICustomerNameRepository _customerNameRepository;
        public CustomerNameService(ICustomerNameRepository repository)
        {
            _customerNameRepository = repository;

        }

        public async Task<List<customerNameDto>> GetAllCustomerName()
        {
            return await _customerNameRepository.GetAllCustomerName();
        }
    }
}
