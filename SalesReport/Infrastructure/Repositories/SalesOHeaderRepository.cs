using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<SalesPersonDto>> GetSalesPerson()
        {
            var query = from sh in _context.SalesOrderHeaders
                        join sp in _context.SalesPeople on sh.SalesPersonID equals sp.BusinessEntityID
                        join p in _context.People on sp.BusinessEntityID equals p.BusinessEntityID
                        group new { sh, sp, p } by new { p.FirstName, p.LastName, SalesYear = sh.OrderDate.Year } into g
                        orderby g.Key.SalesYear
                        select new SalesPersonDto
                        {
                            SalesPersonName = g.Key.FirstName + " " + g.Key.LastName,
                            OrderDate = g.Key.SalesYear,
                            Totaldue = g.Sum(x => x.sh.TotalDue)
                        };
            return await query.ToListAsync();
        }

        public async Task<List<SalesPersonDto>> GetSalesPersonDetails([FromQuery] SalesPersonfilterDto filter)
        {
            var query = from sh in _context.SalesOrderHeaders
                        join sp in _context.SalesPeople on sh.SalesPersonID equals sp.BusinessEntityID
                        join p in _context.People on sp.BusinessEntityID equals p.BusinessEntityID
                        group new { sh, sp, p } by new {p.FirstName, p.LastName, SalesYear = sh.OrderDate.Year } into g
                        orderby g.Key.SalesYear
                        select new SalesPersonDto
                        {
                            SalesPersonName = g.Key.FirstName + " " + g.Key.LastName,
                            OrderDate = g.Key.SalesYear,
                            Totaldue = g.Sum(x => x.sh.TotalDue)
                        };
            if (filter.Year.HasValue)
            {
                query = query.Where(x => x.OrderDate == filter.Year.Value);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.SalesPersonName.Contains(filter.Name));
            }
            var result = await query.Select(x => new SalesPersonDto
            {
                SalesPersonName = x.SalesPersonName,
                OrderDate = x.OrderDate,
                Totaldue = x.Totaldue

            }).ToListAsync();
            return result;
        }
    }
}
