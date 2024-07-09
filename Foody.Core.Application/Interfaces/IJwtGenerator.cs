

using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string Generate(User user);
    }
}
