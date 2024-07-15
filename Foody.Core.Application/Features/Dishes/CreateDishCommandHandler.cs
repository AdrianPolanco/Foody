

using AutoMapper;
using Foody.Core.Application.Constants;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.Features.Dishes
{
    public class CreateDishCommandHandler(IRepository<Dish> dishRepository, 
        IRepository<Ingredient> ingredientRepository, IRepository<DishIngredient> relationRepository, IMapper mapper) : ICommandHandler<CreateDishCommand, CreateDishCommandResult>
    {
        public async Task<CreateDishCommandResult> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        { 
            Dish dish =mapper.Map<Dish>(request);

            List<Ingredient> ingredients = await ingredientRepository.GetAsync(cancellationToken, d => request.Ingredients.Contains(d.Id));
            if(!ingredients.Any()) return new CreateDishCommandResult(null, StatusCodes.Status400BadRequest, DishesConstants.CreateDishInvalid);
            bool categoryExists = Enum.IsDefined(typeof(DishCategory), request.Category);
            if(!categoryExists) return new CreateDishCommandResult(null, StatusCodes.Status400BadRequest, DishesConstants.CategoryDishInvalid);     
            await dishRepository.CreateAsync(dish, cancellationToken);
            List<DishIngredient> dishsIngredients = request.Ingredients.Select(i => new DishIngredient { DishId = dish.Id, IngredientId = i }).ToList();
            await  relationRepository.BulkInsertAsync(dishsIngredients, cancellationToken);
            dish.Ingredients = ingredients;
            CreateDishCommandResult result = new CreateDishCommandResult(dish, StatusCodes.Status201Created, DishesConstants.CreateDishSuccess);
            return result;
        }
    }
}
