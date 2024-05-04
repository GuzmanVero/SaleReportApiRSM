using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SalesReport.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AdvWorksDbContext _context;
        public ProductCategoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategoryDto>> GetAllProductName()
        {
            var productNames = from pro in _context.ProductCategories
                               select new ProductCategoryDto
                               {
                                   Name = pro.Name
                               };
            return await productNames.ToListAsync();
        }
    }
}
