using AutoMapper;
using Foody.API.Requests;
using Foody.API.Responses;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Core.Application.Features.Ingredients.Get;
using Foody.Core.Application.HATEOAS;
using Foody.Core.Application.Interfaces.HATEOAS;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Foody.API.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
  //  [Authorize(Policy = "RequireManagerRole")]
    public class IngredientController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly Hateoas _hateoas;

        public IngredientController(ISender sender, IMapper mapper, Hateoas hateoas)
        {
            _sender = sender;
            _mapper = mapper;
            _hateoas = hateoas;
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
        [HttpPost(Name = nameof(Create))]
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

        [HttpGet("{id}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetIngredientByIdQuery query = new GetIngredientByIdQuery(id);

            GetIngredientByIdQueryResult result = await _sender.Send(query);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet(Name = nameof(Get))]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid? cursor, bool? isNextPage, int pageSize = 5, bool includeFurtherData = false, bool readOnly = false)
        {
            GetIngredientsQuery query = new GetIngredientsQuery(cursor, isNextPage, pageSize, includeFurtherData, readOnly);

            GetIngredientsQueryResult result = await _sender.Send<GetIngredientsQueryResult>(query, cancellationToken);

            return Ok(result);
        }
    }
}
