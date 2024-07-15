using Foody.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.Features.Dishes
{
    public record CreateDishCommandResult(Dish? Dish, int StatusCode, string Message);
}