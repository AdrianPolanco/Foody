
using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Interfaces;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using System.Linq.Expressions;

namespace Foody.Core.Application.Features.Dishes.Get
{
    public class GetDishesByPageQueryHandler(IPaginationService<GetQuery<Dish>, GetQueryResult<Dish>, Dish> paginationService) : IQueryHandler<GetQuery<Dish>, GetQueryResult<Dish>>
    {
        public async Task<GetQueryResult<Dish>> Handle(GetQuery<Dish> request, CancellationToken cancellationToken)
        {
            return await paginationService.GetPage(request, cancellationToken);

            //Omitido por motivos de simplicidad y tiempo
        /*    List<Guid> dishesIds = result.Data.Select(d => d.Id).ToList();

            if(result is not null && request.IncludeFurtherData)
            {
                Expression<Func<DishIngredient, object>>[] includes ={ d => d.Ingredient };
                var dishesIngredients = await dishIngredientService.Get(cancellationToken, di => dishesIds.Contains(di.DishId), readOnly: true, includes: includes);

                List<Ingredient> ingredients = dishesIngredients.Select(di => di.Ingredient).ToList();

                List<Dish> dishes = result.Data;

                dishes.Select(d => d.Ingredients = ingredients.Where(i => dishesIngredients.Any(di => di.DishId == d.Id && di.IngredientId == i.Id)).ToList()).ToList();

                return new GetQueryResult<Dish>(Data: dishes, IsFirstPage: result.IsFirstPage, NextId: result.NextId, PreviousId: result.PreviousId);
            }

            return result!;*/
        }
    }
}
