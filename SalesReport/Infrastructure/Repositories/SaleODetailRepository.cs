﻿namespace SalesReport.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SalesReport.Application.Dtos;
    using SalesReport.Domain.interfaces;
    using SalesReport.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SaleODetailRepository : ISalesODetailRepository
    {
        private readonly AdvWorksDbContext _context;
        public SaleODetailRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<SalesOrderDetail>> GetAllSalesOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsAsync()
        {
            var query = from sd in _context.SalesOrderDetails
                        join sh in _context.SalesOrderHeaders on sd.SalesOrderID equals sh.SalesOrderID
                        join sp in _context.SalesPeople on sh.SalesPersonID equals sp.BusinessEntityID
                        join hre in _context.Employees on sp.BusinessEntityID equals hre.BusinessEntityID
                        join pp in _context.People on hre.BusinessEntityID equals pp.BusinessEntityID
                        join sc in _context.Customers on sh.CustomerID equals sc.CustomerID
                        join ss in _context.Stores on sc.StoreID equals ss.BusinessEntityID
                        join pro in _context.Products on sd.ProductID equals pro.ProductID
                        join pros in _context.ProductSubcategories on pro.ProductSubcategoryID equals pros.ProductSubcategoryID
                        join procat in _context.ProductCategories on pros.ProductCategoryID equals procat.ProductCategoryID
                        join sci in _context.ShoppingCartItems on pro.ProductID equals sci.ProductID
                        join addr1 in _context.Addresses on sh.ShipToAddressID equals addr1.AddressID into addrJoin
                        from addr in addrJoin.DefaultIfEmpty()
                        select new SalesOrderDetailDto
                        {
                            SalesOrderID = sd.SalesOrderID,
                            OrderDate = sh.OrderDate,
                            ShipDate = sh.ShipDate,
                            SalesPersonName = pp.FirstName + " " + pp.LastName,
                            ClientName = ss.Name,
                            ProductName = pro.Name,
                            ProductCategoryName = procat.Name,
                            UnitPrice = sd.UnitPrice,
                            TotalPrice = sd.LineTotal,
                            Quantity = sci.Quantity,
                            ShippingAddress = addr.AddressLine1,
                            BillingAddress = addr.AddressLine2
                        };
            return await query.ToListAsync();
        }
    }
}