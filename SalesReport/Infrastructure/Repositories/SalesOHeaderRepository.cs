using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Infrastructure.Repositories
{
    public class SalesOHeaderRepository : ISalesOHeaderRepository
    {
        private readonly AdvWorksDbContext _context;
        public SalesOHeaderRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesOHeaderDto>> GetAllYears()
        {
            var year = from sh in _context.SalesOrderHeaders
                       group sh by sh.OrderDate.Year into yearGroup
                       select new SalesOHeaderDto
                       {
                           OrderDate = yearGroup.Key             
                       };
            return await year.ToListAsync();
        }

    }
}
