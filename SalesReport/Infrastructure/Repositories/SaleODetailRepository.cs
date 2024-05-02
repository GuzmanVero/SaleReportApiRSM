namespace SalesReport.Infrastructure.Repositories
{
    using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByFilters([FromQuery] SalesFilterDto filter)
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
            if (filter.Year.HasValue)
            {
                query = query.Where(x => x.OrderDate.Year == filter.Year.Value);
            }
            if (!string.IsNullOrEmpty(filter.SalesPersonName))
            {
                query = query.Where(x => x.SalesPersonName == filter.SalesPersonName);
            }
            if (!string.IsNullOrEmpty(filter.Customer))
            {
                query = query.Where(x => x.ClientName == filter.Customer);
            }           
            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(x => x.ProductName == filter.ProductName);
            }
            var result = await query.Select(x => new SalesOrderDetailDto
            {
                SalesOrderID = x.SalesOrderID,
                OrderDate = x.OrderDate,
                ShipDate = x.ShipDate,
                SalesPersonName = x.SalesPersonName,
                ClientName = x.ClientName,
                ProductName = x.ProductName,
                ProductCategoryName = x.ProductCategoryName,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
                Quantity = x.Quantity,
                Orderqty = x.Orderqty,
                ShippingAddress = x.ShippingAddress,
                BillingAddress = x.BillingAddress
            }).ToListAsync();
            return result;
        }

        public async Task<List<SalesOrderDetailDto>> GetSalesOrderDetailsByYear(int year)
        {
            var query = from sd in _context.SalesOrderDetails
                        join sh in _context.SalesOrderHeaders on sd.SalesOrderID equals sh.SalesOrderID
                        where sh.OrderDate.Year == year
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