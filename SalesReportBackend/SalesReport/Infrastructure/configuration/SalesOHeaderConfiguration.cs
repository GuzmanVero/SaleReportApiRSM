using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class SalesOHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable(nameof(SalesOrderHeader), "Sales");

            builder.HasKey(e => e.SalesOrderID);
            builder.Property(e => e.SalesOrderID).HasColumnName("SalesOrderID");
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.ShipDate);
            builder.HasOne(e => e.SalesPerson).WithMany(p => p.SalesOrderHeaders).HasForeignKey(e => e.SalesPersonID);
            builder.HasOne(e => e.Customer).WithMany(c => c.SalesOrderHeaders).HasForeignKey(e => e.CustomerID);
            builder.HasOne(e => e.ShippingAddress).WithMany().HasForeignKey(e => e.ShipToAddressID);
        }
    }
}
