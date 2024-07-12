

using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;

namespace Foody.Core.Application.Features.Ingredients.Get
{
    public class GetIngredientByIdQueryHandler(IEntityService<Ingredient> service) : IQueryHandler<GetIngredientByIdQuery, GetIngredientByIdQueryResult?>
    {
        public async Task<GetIngredientByIdQueryResult?> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            Ingredient? ingredient = await service.GetByIdAsync(request.Id, cancellationToken);

            if(ingredient is null)return null;

            return new GetIngredientByIdQueryResult(ingredient)
            {
                Id = ingredient.Id
            };
            
        }
    }
}
