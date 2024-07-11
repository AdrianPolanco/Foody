

using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Interfaces
{
    public interface IJwtGenerator
    {
       public string Generate(User user);
    }
}
