using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address), "Person");
            builder.HasKey(e => e.AddressID);
            builder.Property(e => e.AddressID).HasColumnName("AddressID");
            builder.Property(e => e.AddressLine1).IsRequired();
            builder.Property(e => e.AddressLine2);
        }
    }
}
