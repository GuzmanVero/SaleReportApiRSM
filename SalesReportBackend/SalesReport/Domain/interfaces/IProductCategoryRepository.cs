using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategoryDto>> GetAllProductName();
    }
}
