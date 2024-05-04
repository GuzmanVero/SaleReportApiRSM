namespace SalesReport.Infrastructure
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SalesReport.Domain.Models;
    using System.Data;
    using System.Reflection;

    public class AdvWorksDbContext : DbContext
    {
        public AdvWorksDbContext()
        {
        }

        public AdvWorksDbContext(DbContextOptions<AdvWorksDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesPerson> SalesPeople { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories{ get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
