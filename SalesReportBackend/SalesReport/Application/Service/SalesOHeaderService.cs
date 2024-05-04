using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<SalesPersonDto>> GetSalesPerson()
        {
            return await _salesOHeaderRepository.GetSalesPerson();
        }

        public async Task<List<SalesPersonDto>> GetSalesPersonDetails([FromQuery] SalesPersonfilterDto filter)
        {
            return await _salesOHeaderRepository.GetSalesPersonDetails(filter);
        }
    }
}
