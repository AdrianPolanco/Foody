
using MediatR;

namespace Foody.Core.Application.Interfaces.MediatR.CQRS.Queries
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }
}
