

using AutoMapper;
using Foody.Core.Application.Constants;
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Foody.Core.Application.Features.Dishes.Update
{
    public class UpdateDishCommandHandler(IRepository<Dish> dishRepository,
        IRepository<Ingredient> ingredientRepository, IRepository<DishIngredient> relationRepository, IMapper mapper) : ICommandHandler<UpdateDishCommand, UpdateDishCommandResult>
    {
        public async Task<UpdateDishCommandResult> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            Dish? dish = mapper.Map<Dish>(request);
            Expression<Func<Dish, object>>[] includesRelation = { d => d.DishesIngredients };
            dish = await dishRepository.GetByIdAsync(dish.Id, cancellationToken, includes: includesRelation);

            if (dish is null) return new UpdateDishCommandResult(null, StatusCodes.Status404NotFound, DishesConstants.DishNotFound);
            List<Ingredient> ingredients = await ingredientRepository.GetAsync(cancellationToken, d => request.Ingredients.Contains(d.Id));

            if (!ingredients.Any()) return new UpdateDishCommandResult(null, StatusCodes.Status400BadRequest, DishesConstants.CreateDishInvalid);
            bool categoryExists = Enum.IsDefined(typeof(DishCategory), request.Category);

            if (!categoryExists) return new UpdateDishCommandResult(null, StatusCodes.Status400BadRequest, DishesConstants.CategoryDishInvalid);

            List<DishIngredient> dishIngredients = request.Ingredients.Select(i => new DishIngredient { DishId = dish.Id, IngredientId = i }).ToList();
            Expression<Func<DishIngredient, object>>[] includesIngredients = { d => d.Ingredient };

     
            await relationRepository.BulkDeleteAsync(dish.DishesIngredients, cancellationToken);
            await relationRepository.BulkInsertAsync(dishIngredients, cancellationToken);

            dish.Name = request.Name;
            dish.Price = request.Price;
            dish.PeopleQuantity = request.PeopleQuantity;
            dish.Category = request.Category;
           
            await dishRepository.UpdateAsync(dish, cancellationToken);
          
            List<DishIngredient> dishesIngredients = await relationRepository.GetAsync(cancellationToken, d => request.Ingredients.Contains(d.Id) && d.DishId == dish.Id, includes: includesIngredients);

            List<Ingredient> newIngredients = dishesIngredients.Select(d => d.Ingredient).ToList();

            dish.Ingredients = newIngredients;
            dish.DishesIngredients.Clear();
            UpdateDishCommandResult result = new UpdateDishCommandResult(dish, StatusCodes.Status200OK, DishesConstants.CreateDishSuccess);
            return result;
        }
    }
}
