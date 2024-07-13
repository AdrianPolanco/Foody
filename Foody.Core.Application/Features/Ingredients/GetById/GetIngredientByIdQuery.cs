using Foody.Core.Application.Interfaces.MediatR.CQRS;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Queries;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Ingredients.Get
{
    public record GetIngredientByIdQueryResult(Ingredient? Ingredient) : IResponse {
        public Guid Id { get; set; } = default;
    }
    public record GetIngredientByIdQuery(Guid Id) : IQuery<GetIngredientByIdQueryResult>;
}
