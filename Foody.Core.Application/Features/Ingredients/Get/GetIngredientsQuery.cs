using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Ingredients.Get
{
    public record GetIngredientsQuery(Guid? LastId, bool? IsNextPage, int PageSize = 5, bool IncludeFurtherData = false, bool ReadOnly = true) 
        : GetQuery<Ingredient>(LastId, IsNextPage, PageSize, ReadOnly), IQuery<GetIngredientsQueryResult>;
    public record GetIngredientsQueryResult(List<Ingredient> Data, Guid? PreviousId, Guid? NextId, bool IsFirstPage) : GetQueryResult<Ingredient>(Data, PreviousId, NextId, IsFirstPage);
}
