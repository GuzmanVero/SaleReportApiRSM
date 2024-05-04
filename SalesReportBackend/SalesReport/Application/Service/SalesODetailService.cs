using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilterDto filter)
        {
            return await _salesODetailRepository.GetSalesOrderDetailsByFilters(filter);
        }

        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByYear(int year)
        {
            return await _salesODetailRepository.GetSalesOrderDetailsByYear(year);
        }
    }
}
