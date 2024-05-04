using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            builder.ToTable(nameof(SalesPerson), "Sales");
            builder.HasKey(e => e.BusinessEntityID);
            builder.HasOne(e => e.Employee)
                .WithOne()
                .HasForeignKey<SalesPerson>(e => e.BusinessEntityID);
        }
    }
}
