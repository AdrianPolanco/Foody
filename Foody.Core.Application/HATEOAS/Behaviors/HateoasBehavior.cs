
using Foody.Core.Application.Interfaces.HATEOAS;
using Foody.Core.Application.Interfaces.MediatR.CQRS;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.HATEOAS.Behaviors
{
    public class HateoasBehavior<TRequest, TResponse>(ILinkFactory linkFactory, Hateoas hateoas, IHttpContextAccessor httpContextAccessor) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull, IResponse
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
 var httpContext = httpContextAccessor.HttpContext;
            TResponse? response = await next();

           
            HttpMethod method = httpContext?.Request.Method switch
            {
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => HttpMethod.Get
            };
            hateoas.Data[Hateoas.DataKey].Add(new LinkData(hateoas.ActionName,method, HateoasConstants.SELF, new { id = response.Id }));
          //  hateoas.Data[Hateoas.DataKey].AddRange(hateoas.GetRoutes().Select(r => r.Links);
            hateoas.Data[Hateoas.DataKey].ForEach(ld => linkFactory.CreateLink(ld.endpoint, ld.rel, ld.method, ld?.routeValues));

            hateoas.Links = linkFactory.GetLinks();

            return response;
        }
    }

}
