
using Foody.Core.Application.Services;
using Foody.Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Foody.Core.Application.Extensions.DI
{
    public static class ApplicationLayer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            return services;
        }
    }
}
