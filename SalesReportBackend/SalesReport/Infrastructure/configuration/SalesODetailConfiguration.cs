using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class SalesODetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            builder.ToTable(nameof(SalesOrderDetail), "Sales");

            builder.HasKey(e => e.SalesOrderID);
            builder.Property(e => e.SalesOrderID).HasColumnName("SalesOrderID");
            builder.Property(e => e.UnitPrice).IsRequired();
            builder.Property(e => e.LineTotal).IsRequired();
            builder.HasOne(e => e.SalesOrderHeader).WithMany(p => p.SalesOrderDetails).HasForeignKey(e => e.SalesOrderID);
            builder.HasOne(e => e.Product).WithMany(p => p.SalesOrderDetails).HasForeignKey(e => e.ProductID);
        }
    }
}
