using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;

namespace Foody.Core.Application.Features.Common
{
    public abstract record GetQuery<T>(Guid? LastId, bool? IsNextPage, int PageSize = 5, bool IncludeFurtherData = false, bool ReadOnly = true) : IQuery<GetQueryResult<T>>;

    public abstract record GetQueryResult<T>(List<T> Data, Guid? PreviousId, Guid? NextId, bool IsFirstPage);
}
