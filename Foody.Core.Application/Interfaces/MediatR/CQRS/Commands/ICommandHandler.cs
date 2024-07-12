

using MediatR;

namespace Foody.Core.Application.Interfaces.MediatR.CQRS.Commands
{
   public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest, Unit> where TRequest : ICommand
    {
    }

    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
