using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Interfaces;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Tables.Get
{
    public class GetTableQueryHandler(IPaginationService<GetQuery<DinnerTable>, GetQueryResult<DinnerTable>,DinnerTable> paginationService)
        : IQueryHandler<GetQuery<DinnerTable>, GetQueryResult<DinnerTable>>
    {
        public async Task<GetQueryResult<DinnerTable>> Handle(GetQuery<DinnerTable> request, CancellationToken cancellationToken)
        {
            return await paginationService.GetPageAsync(request, cancellationToken);
        }
    }
}
