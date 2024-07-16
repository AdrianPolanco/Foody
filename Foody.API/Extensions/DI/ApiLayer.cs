using Foody.API.Services.Factories;
using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces.HATEOAS;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Foody.API.Extensions.DI
{
    public static class ApiLayer
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                //Specifying the version
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Foody API", Version = "v1" });
                //Adding the security definitions with the name of "Bearer"
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    //Will be ubicated in the Header of the HTTP Request
                    In = ParameterLocation.Header,
                    //Description
                    Description = "Please enter a valid token",
                    //nAME
                    Name = "Authorization",
                    //Type of security Scheme
                    Type = SecuritySchemeType.Http,
                    //Format of the bearer toekn
                    BearerFormat = "JWT",
                    //Scheme
                    Scheme = "Bearer"
                });
                //
                option.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            //New Security Scheme
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    //Reference set to a SecurityScheme reference type
                                    Type=ReferenceType.SecurityScheme,
                                    //Reference set to "Bearer"
                                    Id="Bearer"
                                }
                            },
                            //This empty array indicates that the security scheme does not require any additional permission, else, we should specify them inside the array
                            new string[]{}
                        }
                    });

                option.EnableAnnotations();
            });

            services.AddHttpContextAccessor();
            services.AddScoped<ILinkFactory, LinkFactory>();

            return services;
        }
    }
}
