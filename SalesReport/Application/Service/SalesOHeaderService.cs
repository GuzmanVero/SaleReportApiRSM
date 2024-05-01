using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using SalesReport.Infrastructure.Repositories;

namespace SalesReport.Application.Service
{
    public class SalesOHeaderService : ISalesOHeaderService
    {
        private readonly ISalesOHeaderRepository _salesOHeaderRepository;
        public SalesOHeaderService(ISalesOHeaderRepository repository)
        {
            _salesOHeaderRepository = repository;

        }

        public async Task<List<SalesOHeaderDto>> GetAllYears()
        {
            return await _salesOHeaderRepository.GetAllYears();
        }
    }
}
