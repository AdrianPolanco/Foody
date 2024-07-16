using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Interfaces;
using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Interfaces;


namespace Foody.Core.Application.Services
{
    public class PaginationService<TQuery, TResponse, TEntity> : IPaginationService<TQuery, TResponse, TEntity>
        where TEntity : Entity
        where TResponse : GetQueryResult<TEntity>
        where TQuery : GetQuery<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public PaginationService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<GetQueryResult<TEntity>> GetPage(TQuery query, CancellationToken cancellationToken)
        {
            List<TEntity> entities = await _repository.GetByPagesAsync(cancellationToken: cancellationToken, cursor: query.LastId, isNextPage: query.IsNextPage, readOnly: query.ReadOnly, pageSize: query.PageSize, includes: null);
            var firstIngredientList = await _repository.GetAsync(cancellationToken: cancellationToken, filter: null, readOnly: true, ignoreQueryFilters: false, includes: null);
            var firstIngredient = firstIngredientList.FirstOrDefault();

            Guid firstIngredientId = firstIngredient is null ? Guid.Empty : firstIngredient.Id;

            //TODO: Manejar NullReferenceException cuando no hay ingredientes recuperados
            var firstRetrievedIngredient = entities.FirstOrDefault();

            if (firstRetrievedIngredient is null) return new GetQueryResult<TEntity>(Data: new List<TEntity>(), IsFirstPage: false, NextId: null, PreviousId: query.LastId);
            bool isFirstPage = !query.LastId.HasValue || (query.LastId.HasValue && firstRetrievedIngredient!.Id == firstIngredientId);
            bool hasNextPage = entities.Count > query.PageSize || (query.LastId is not null && query.IsNextPage is false);
            if (entities.Count > query.PageSize) entities.RemoveAt(entities.Count - 1);

            Guid? nextId = hasNextPage ? entities.Last().Id : null;

            Guid? previousId = entities.Count > 0 && !isFirstPage ? entities.First().Id : null;

            return new GetQueryResult<TEntity>(Data: entities, IsFirstPage: isFirstPage, NextId: nextId, PreviousId: previousId);
        }
    }
    }

