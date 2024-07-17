using Foody.Core.Domain.Interfaces;
using AutoMapper;
using Foody.API.Requests.Ingredient;
using Foody.API.Responses;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Core.Application.Features.Ingredients.Get;
using Foody.Core.Application.HATEOAS;
using Foody.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Foody.Shared.Hateoas;
using Foody.Core.Application.Features.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Foody.API.Controllers
{
    [ApiController]
    [Route($"api/{ControllersConstants.INGREDIENTS}")]
    [Authorize(Policy = "RequireManagerRole")]
    public class IngredientController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IEntityService<Ingredient> _service;   

        public IngredientController(ISender sender, IMapper mapper, IEntityService<Ingredient> service)
        {
            _sender = sender;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost(Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Create)}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Crear ingrediente", Description = "Crea un ingrediente con sus respectivos datos.")]
        public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request)
        {
           CreateIngredientCommand command = _mapper.Map<CreateIngredientCommand>(request);

           CreateIngredientCommandResult result = await _sender.Send(command);

           CreateIngredientResponse response = new CreateIngredientResponse(result/*, _hateoas.Links*/);

            return CreatedAtAction(nameof(Create), response);
        }

        [HttpGet("{id}", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(GetById)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener ingrediente por id", Description = "Obtiene un ingrediente por su id.")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetIngredientByIdQuery query = new GetIngredientByIdQuery(id);

            GetIngredientByIdQueryResult result = await _sender.Send(query);

            if(result == null) return NoContent();

            return Ok(result);
        }

        [HttpGet(Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Get)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener ingredientes", Description = "Obtiene todos los ingredientes.")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            List<Ingredient> ingredients = await _service.GetAsync(cancellationToken: cancellationToken, filter: null, readOnly: true, ignoreQueryFilters: false, includes: null);   

            return Ok(ingredients);
        }

        [HttpGet("pages", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(GetPages)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener ingredientes paginados", Description = "Obtiene los ingredientes de forma paginada.")]
        public async Task<IActionResult> GetPages(CancellationToken cancellationToken, Guid? cursor, bool? isNextPage, int pageSize = 5)
        {
            GetQuery<Ingredient> query = new GetQuery<Ingredient>(cursor, isNextPage, pageSize);

            GetQueryResult<Ingredient> result = await _sender.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPut("{id}", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Update)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Actualizar ingrediente", Description = "Actualiza un ingrediente por su id.")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateIngredientRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(request);

            Ingredient? ingredient = await _service.GetByIdAsync(id, cancellationToken);

            if(ingredient is null) return NotFound();

            ingredient.Name = request.Name;

            Ingredient updatedIngredient = await _service.UpdateAsync(ingredient, cancellationToken);

            return Ok(updatedIngredient);
        }
    }
}
