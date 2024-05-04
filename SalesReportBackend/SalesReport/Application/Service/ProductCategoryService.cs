using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Application.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productRepository;
        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _productRepository = repository;

        }

        public async Task<List<ProductCategoryDto>> GetAllProductName()
        {
            return await _productRepository.GetAllProductName();
        }
    }
}
