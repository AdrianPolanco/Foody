

using Foody.Core.Application.Dtos;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;

namespace Foody.Core.Application.Features.Tables.GetPendingOrders
{
    public record GetPendingOrdersQuery(Guid Id) : IQuery<GetPendingOrdersQueryResult>;

    public record GetPendingOrdersQueryResult(GetTableOrdersDto? Orders, int TotalPendingOrders, int Status);

}
