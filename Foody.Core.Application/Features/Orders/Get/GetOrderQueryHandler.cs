
using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Interfaces;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Orders.Get
{
    public class GetOrderQueryHandler(IPaginationService<GetQuery<Order>, GetQueryResult<Order>, Order> paginationService) : IQueryHandler<GetQuery<Order>, GetQueryResult<Order>>
    {
        public async Task<GetQueryResult<Order>> Handle(GetQuery<Order> request, CancellationToken cancellationToken)
        {
            return await paginationService.GetPageAsync(request, cancellationToken);
        }
    }
}
