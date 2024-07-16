using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Tables.GetById
{
    public record GetTableByIdQuery(Guid Id): IQuery<DinnerTable>;
   
}
