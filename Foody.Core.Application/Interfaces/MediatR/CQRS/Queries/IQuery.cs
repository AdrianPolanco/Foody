using MediatR;

namespace Foody.Core.Application.Interfaces.MediatR.CQRS.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
