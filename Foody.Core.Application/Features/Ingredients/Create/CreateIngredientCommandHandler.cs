

using AutoMapper;
using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces.HATEOAS;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using MediatR;

namespace Foody.Core.Application.Features.Ingredients.Create
{
    public class CreateIngredientCommandHandler(IEntityService<Ingredient> service, IMapper mapper) : ICommandHandler<CreateIngredientCommand, CreateIngredientCommandResult>
    {

        public async Task<CreateIngredientCommandResult> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            Ingredient ingredient = mapper.Map<Ingredient>(request);

            ingredient = await service.CreateAsync(ingredient, cancellationToken);

            return mapper.Map<CreateIngredientCommandResult>(ingredient);
        }
    }
}
