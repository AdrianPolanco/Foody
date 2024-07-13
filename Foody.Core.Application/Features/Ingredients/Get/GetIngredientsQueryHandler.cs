using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;


namespace Foody.Core.Application.Features.Ingredients.Get
{
    public class GetIngredientsQueryHandler : IQueryHandler<GetIngredientsQuery, GetIngredientsQueryResult>
    {
        private readonly IRepository<Ingredient> _repository;

        public GetIngredientsQueryHandler(IRepository<Ingredient> repository)
        {
            _repository = repository;
        }

        public async Task<GetIngredientsQueryResult> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            List<Ingredient> ingredients = await _repository
                .GetByPagesAsync(cancellationToken: cancellationToken, cursor: request.LastId, isNextPage: request.IsNextPage, readOnly: request.ReadOnly, pageSize: request.PageSize, includes: null);

            var firstIngredientList = await _repository.Get(cancellationToken: cancellationToken, filter: null, readOnly: true, ignoreQueryFilters: false, includes: null);

            var firstIngredient = firstIngredientList.FirstOrDefault();

            Guid firstIngredientId = firstIngredient is null ? Guid.Empty : firstIngredient.Id;

            //TODO: Manejar NullReferenceException cuando no hay ingredientes recuperados
            var firstRetrievedIngredient = ingredients.FirstOrDefault();

            if(firstRetrievedIngredient is null) return new GetIngredientsQueryResult(Data: new List<Ingredient>(), IsFirstPage: false, NextId: null, PreviousId: request.LastId);

            bool isFirstPage = !request.LastId.HasValue || (request.LastId.HasValue && firstRetrievedIngredient!.Id == firstIngredientId);

            bool hasNextPage = ingredients.Count > request.PageSize || (request.LastId is not null && request.IsNextPage is false);

            if(ingredients.Count > request.PageSize) ingredients.RemoveAt(ingredients.Count - 1);
            
            Guid? nextId = hasNextPage ? ingredients.Last().Id : null;

            Guid? previousId = ingredients.Count > 0 && !isFirstPage ? ingredients.First().Id : null;

            return new GetIngredientsQueryResult(Data: ingredients, IsFirstPage: isFirstPage, NextId: nextId, PreviousId: previousId);
        }
    }
}
