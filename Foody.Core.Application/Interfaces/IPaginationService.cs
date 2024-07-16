

using Foody.Core.Application.Features.Common;
using Foody.Core.Domain.Entities.Base;

namespace Foody.Core.Application.Interfaces
{
    public interface IPaginationService<TQuery, TResponse, TEntity>
        where TEntity : Entity
        where TResponse : GetQueryResult<TEntity>
        where TQuery : GetQuery<TEntity>
    {
        Task<GetQueryResult<TEntity>> GetPage(TQuery query, CancellationToken cancellationToken);
    }
}
