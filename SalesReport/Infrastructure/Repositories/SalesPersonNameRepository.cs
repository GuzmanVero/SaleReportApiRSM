using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Infrastructure.Repositories
{
    public class SalesPersonNameRepository : ISalesPersonNameRepository
    {
        private readonly AdvWorksDbContext _context;
        public SalesPersonNameRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesPersonNameDto>> GetAllSalesPersonName()
        {
            var salesPersonNames = from sp in _context.People
                                   group sp by sp.FirstName + " " + sp.LastName into nameGroup
                                   select new SalesPersonNameDto
                               {
                                   Name = nameGroup.Key
                               };
            return await salesPersonNames.ToListAsync();
        }
    }
}
