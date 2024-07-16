

using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;

namespace Foody.Core.Application.Features.Orders.GetById
{
    public record GetOrderByIdQuery(Guid Id, bool IncludeFurtherData = false) : IQuery<GetOrderByIdQueryResult>;

    public record GetOrderByIdQueryResult(OrderDto? Order, int StatusCode, string Message);
}
