using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Domain.Entities
{
    public class User: Entity
    {
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ApplicationRoles Role { get; set; }
    }
}
