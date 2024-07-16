
using MediatR;

namespace Foody.Core.Application.Interfaces.MediatR.CQRS.Commands
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
