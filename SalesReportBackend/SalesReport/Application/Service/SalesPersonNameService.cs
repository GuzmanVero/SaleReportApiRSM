using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Application.Service
{
    public class SalesPersonNameService : ISalesPersonNameService
    {
        private readonly ISalesPersonNameRepository salesPersonNameRepository;
        public SalesPersonNameService(ISalesPersonNameRepository repository)
        {
            salesPersonNameRepository = repository;

        }

        public async Task<List<SalesPersonNameDto>> GetAllSalesPersonName()
        {
            return await salesPersonNameRepository.GetAllSalesPersonName();
        }
    }
}
