
using AutoMapper;
using Foody.API.Requests.Dishes;
using Foody.API.Responses;
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Features.Dishes.Update;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Foody.API.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController(ISender sender, IMapper mapper, IEntityService<Dish> genericService) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.DISHES}/{nameof(Create)}")]
        public async Task<IActionResult> Create([FromBody] CreateDishRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateDishCommand command =mapper.Map<CreateDishCommand>(request);

            CreateDishCommandResult result = await sender.Send(command, cancellationToken);

            CreateDishResponse response = new CreateDishResponse(result);

            return CreatedAtAction(nameof(Create), response);
        }

        [HttpPut("{id}", Name = $"{ControllersConstants.DISHES}/{nameof(Update)}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDishRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            UpdateDishCommand command = mapper.Map<UpdateDishCommand>(request);

            command.Id = id;

            UpdateDishCommandResult result = await sender.Send(command, cancellationToken);

            UpdateDishResponse response = new UpdateDishResponse(result);

            return Ok(response);
        }

        [HttpGet(Name = $"{ControllersConstants.DISHES}/{nameof(Get)}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {         
            var result = await genericService.Get(cancellationToken: cancellationToken, filter: null, readOnly: true);

            return Ok(result);
        }
    }
}
