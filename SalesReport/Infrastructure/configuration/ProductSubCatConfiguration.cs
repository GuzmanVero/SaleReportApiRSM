using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class ProductSubCatConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            builder.ToTable(nameof(ProductSubcategory), "Production");
            builder.HasKey(e => e.ProductSubcategoryID);
            builder.HasOne(e => e.ProductCategory)
                .WithMany(pc => pc.ProductSubcategories)
                .HasForeignKey(e => e.ProductCategoryID);
        }
    }
}
