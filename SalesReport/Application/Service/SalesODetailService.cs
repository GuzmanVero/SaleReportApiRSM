using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using SalesReport.Domain.Models;

namespace SalesReport.Application.Service
{
    public class SalesODetailService : ISalesODetailService
    {
        private readonly ISalesODetailRepository _salesODetailRepository;
        public SalesODetailService(ISalesODetailRepository repository)
        {
            _salesODetailRepository = repository;

        }
        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync()
        {
            return await _salesODetailRepository.GetSalesOrderDetailsAsync();
        }
    }
}
