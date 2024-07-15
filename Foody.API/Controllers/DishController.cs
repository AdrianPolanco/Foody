
using AutoMapper;
using Foody.API.Requests.Dishes;
using Foody.API.Responses;
using Foody.Core.Application.Features.Dishes;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foody.API.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController(ISender sender, IMapper mapper) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.DISHES}/{nameof(Create)}")]
        public async Task<IActionResult> Create([FromBody] CreateDishRequest request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateDishCommand command =mapper.Map<CreateDishCommand>(request);

            CreateDishCommandResult result = await sender.Send(command);

            CreateDishResponse response = new CreateDishResponse(result);

            return CreatedAtAction(nameof(Create), response);
        }
    }
}
