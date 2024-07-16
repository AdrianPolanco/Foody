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


namespace Foody.API.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
   // [Authorize(Policy = "RequireManagerRole")]
    public class IngredientController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly Hateoas _hateoas;
        private readonly IEntityService<Ingredient> _service;   

        public IngredientController(ISender sender, IMapper mapper, Hateoas hateoas, IEntityService<Ingredient> service)
        {
            _sender = sender;
            _mapper = mapper;
            _hateoas = hateoas;
            _service = service;
         /*   _hateoas.Routes.Add(new HateoasRoute
            {
                ControllerName = ControllerContext.ActionDescriptor.ControllerName,
                Links = new List<BaseLinkData>
                {
                    new BaseLinkData("Get", HttpMethod.Get, "Get"),
                    new BaseLinkData("Create", HttpMethod.Post, "Create")
                }
            });*/
        }
        [HttpPost(Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Create)}")]
        public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request)
        {
            _hateoas.ActionName = ControllerContext.ActionDescriptor.ActionName;
            _hateoas.ControllerName = ControllerContext.ActionDescriptor.ControllerName;
            // hateoas.Action = (string endpoint, HttpMethod method, string rel,  object? routeValues) => new LinkData(endpoint, method, rel, routeValues);
           CreateIngredientCommand command = _mapper.Map<CreateIngredientCommand>(request);

           CreateIngredientCommandResult result = await _sender.Send(command);

           CreateIngredientResponse response = new CreateIngredientResponse(result/*, _hateoas.Links*/);

            return CreatedAtAction(nameof(Create), response);
        }

        [HttpGet("{id}", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(GetById)}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetIngredientByIdQuery query = new GetIngredientByIdQuery(id);

            GetIngredientByIdQueryResult result = await _sender.Send(query);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet(Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Get)}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            List<Ingredient> ingredients = await _service.Get(cancellationToken: cancellationToken, filter: null, readOnly: true, ignoreQueryFilters: false, includes: null);   

            return Ok(ingredients);
        }

        [HttpGet("pages", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(GetPages)}")]
        public async Task<IActionResult> GetPages(CancellationToken cancellationToken, Guid? cursor, bool? isNextPage, int pageSize = 5, bool includeFurtherData = false, bool readOnly = false)
        {
            GetIngredientsQuery query = new GetIngredientsQuery(cursor, isNextPage, pageSize, includeFurtherData, readOnly);

            GetQueryResult<Ingredient> result = await _sender.Send<GetQueryResult<Ingredient>>(query, cancellationToken);

            return Ok(result);
        }

        [HttpPut("{id}", Name = $"{ControllersConstants.INGREDIENTS}/{nameof(Update)}")]
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
