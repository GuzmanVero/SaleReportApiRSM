using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable(nameof(ShoppingCartItem), "Sales");
            builder.HasKey(e => e.ShoppingCartItemID);
            builder.HasOne(e => e.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(e => e.ProductID);
        }
    }
}
