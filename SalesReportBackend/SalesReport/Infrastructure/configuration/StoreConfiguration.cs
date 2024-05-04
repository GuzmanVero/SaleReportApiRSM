using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable(nameof(Store), "Sales");
            builder.HasKey(e => e.BusinessEntityID);
        }
    }
}
