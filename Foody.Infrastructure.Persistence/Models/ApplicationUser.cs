

using Microsoft.AspNetCore.Identity;

namespace Foody.Infrastructure.Persistence.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
    }
}
