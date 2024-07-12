

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Foody.Shared.DI
{
    public static class SharedLayer
    {
        //Recibiendo los parametros de los otros proyectos para buscar los perfiles de AutoMapper
        public static IServiceCollection AddProfiles(this IServiceCollection services, params Assembly[] assemblies)
        {
            var profiles = assemblies.SelectMany(a => a.GetTypes())
                                     .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract)
                                     .ToArray();

            services.AddAutoMapper(config =>
            {
                foreach (var profile in profiles)
                {
                    config.AddProfile(profile);
                }
            }, assemblies);

            return services;
        }

        public static IServiceCollection AddCQRS(this IServiceCollection services, params Assembly[] assemblies)
        {

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies));

            return services;
        }
    }
}
