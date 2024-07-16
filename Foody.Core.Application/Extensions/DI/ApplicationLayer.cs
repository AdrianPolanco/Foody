
using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces;
using Foody.Core.Application.Services;
using Foody.Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Foody.Core.Application.Extensions.DI
{
    public static class ApplicationLayer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<Hateoas>();
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            services.AddScoped(typeof(IPaginationService<,,>), typeof(PaginationService<,,>));
          //  services.AddScoped(typeof(IPipelineBehavior<,>), typeof(HateoasBehavior<,>));
            return services;
        }
    }
}
