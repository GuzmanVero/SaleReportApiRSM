using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer), "Sales");
            builder.HasKey(e => e.CustomerID);
            builder.HasOne(e => e.Store)
                .WithMany(s => s.Customers)
                .HasForeignKey(e => e.StoreID);
        }
    }
}
