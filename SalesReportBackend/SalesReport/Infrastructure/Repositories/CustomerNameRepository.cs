using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Infrastructure.Repositories
{
    public class CustomerNameRepository : ICustomerNameRepository
    {
        private readonly AdvWorksDbContext _context;
        public CustomerNameRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<customerNameDto>> GetAllCustomerName()
        {
            var customerNames = from c in _context.Stores
                                group c by c.Name into nameGroup                                
                                select new customerNameDto
                               {
                                   Name = nameGroup.Key
                               };
            return await customerNames.ToListAsync();
        }
    }
}
