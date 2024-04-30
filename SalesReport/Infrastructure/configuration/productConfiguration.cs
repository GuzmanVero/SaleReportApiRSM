using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class productConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.ProductID);
            builder.Property(e => e.ProductID).HasColumnName("ProductID");
            builder.Property(e => e.Name).IsRequired();
            builder.HasOne(e => e.ProductSubcategory).WithMany(p => p.Products).HasForeignKey(e => e.ProductSubcategoryID);
        }
    }
}
