using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalesReport.Domain.Models;

namespace SalesReport.Infrastructure.configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee), "HumanResources");
            builder.HasKey(e => e.BusinessEntityID);
            builder.HasOne(e => e.Person)
                .WithOne()
                .HasForeignKey<Employee>(e => e.BusinessEntityID);
        }
    }
}
