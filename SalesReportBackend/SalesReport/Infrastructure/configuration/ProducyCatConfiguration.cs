using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class ProducyCatConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), "Production");
            builder.HasKey(e => e.ProductCategoryID);
        }
    }
}
