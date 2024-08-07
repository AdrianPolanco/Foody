﻿
using AutoMapper;
using Foody.API.Requests.Dishes;
using Foody.API.Responses;
using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Features.Dishes.Update;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Foody.API.Controllers
{
    [Route($"api/{ControllersConstants.DISHES}")]
    [ApiController]
    [Authorize(Policy = "RequireManagerRole")]
    public class DishController(ISender sender, IMapper mapper, IEntityService<Dish> genericService) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.DISHES}/{nameof(Create)}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Crear platillo", Description = "Crea un platillo con un nombre, precio, descripción y sus ingredientes")]
        public async Task<IActionResult> Create([FromBody] CreateDishRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateDishCommand command =mapper.Map<CreateDishCommand>(request);

            CreateDishCommandResult result = await sender.Send(command, cancellationToken);

            if (result.StatusCode == 400) return BadRequest(result.Message);

            CreateDishResponse response = new CreateDishResponse(result);

            return CreatedAtAction(nameof(Create), response);
        }

        [HttpPut("{id}", Name = $"{ControllersConstants.DISHES}/{nameof(Update)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Actualizar platillo", Description = "Actualiza los ingredientes de un platillo dado")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Obtener platillos", Description = "Obtiene todos los platillos registrados")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {         
            var result = await genericService.GetAsync(cancellationToken: cancellationToken, filter: null, readOnly: true);

            if(result.Count == 0) return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}", Name = $"{ControllersConstants.DISHES}/{nameof(GetById)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Obtener platillo por ID", Description = "Obtiene un platillo por su ID")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await genericService.GetByIdAsync(id, cancellationToken, true);

            if(result is null) return NoContent();

            return Ok(result);
        }

        [HttpGet("pages", Name = $"{ControllersConstants.DISHES}/{nameof(GetPages)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Obtener platillos paginados", Description = "Obtiene los platillos registrados de forma paginada")]
        public async Task<IActionResult> GetPages(CancellationToken cancellationToken, Guid? cursor, bool? isNextPage, int pageSize = 5, bool includeFurtherData = false)
        {
            GetQuery<Dish> query = new GetQuery<Dish>(cursor, isNextPage, pageSize, includeFurtherData);

            GetQueryResult<Dish> result = await sender.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
