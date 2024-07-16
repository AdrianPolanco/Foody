

using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;

namespace Foody.Core.Application.Features.Tables.GetById
{
    public class GetTableByIdQueryHandler(IEntityService<DinnerTable> tableService) : IQueryHandler<GetTableByIdQuery, DinnerTable?>
    {
        public async Task<DinnerTable?> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            return await tableService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
