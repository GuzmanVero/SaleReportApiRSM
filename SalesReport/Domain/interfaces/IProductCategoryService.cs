using SalesReport.Application.Dtos;

namespace SalesReport.Domain.interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDto>> GetAllProductName();
    }
}
