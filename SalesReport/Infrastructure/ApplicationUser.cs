using Microsoft.AspNetCore.Identity;

namespace SalesReport.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
