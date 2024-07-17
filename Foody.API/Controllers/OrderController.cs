using AutoMapper;
using Foody.API.Requests.Orders;
using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Features.Orders.Create;
using Foody.Core.Application.Features.Orders.Delete;
using Foody.Core.Application.Features.Orders.GetById;
using Foody.Core.Application.Features.Orders.Update;
using Foody.Core.Domain.Entities;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Foody.API.Controllers
{
    [Route($"api/{ControllersConstants.ORDERS}")]
    [ApiController]
    [Authorize(Policy = "RequireWaiterRole")]
    public class OrderController(ISender sender, IMapper mapper) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.ORDERS}/{nameof(Create)}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Crear orden", Description = "Crea una orden con un varios platillos y un precio calculado")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateOrderCommand command = mapper.Map<CreateOrderCommand>(request);

            CreateOrderCommandResult result = await sender.Send(command, cancellationToken);

            if (result.Order is null && result.StatusCode == StatusCodes.Status404NotFound) return NotFound(result);

            if (result.Order is null && result.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(result);

            return CreatedAtAction(nameof(Create), result);
        }

        [HttpPut(Name = $"{ControllersConstants.ORDERS}/{nameof(Update)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Actualizar orden", Description = "Actualiza los platillos de una orden, y a partir de los nuevos platillos se recalcula el subtotal")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            UpdateOrderCommand command = mapper.Map<UpdateOrderCommand>(request);

            UpdateOrderCommandResult result = await sender.Send(command, cancellationToken);

            if (result.Order is null && result.StatusCode == StatusCodes.Status404NotFound) return NotFound(result);

            if (result.Order is null && result.StatusCode == StatusCodes.Status400BadRequest) return BadRequest(result);

            return NoContent();
        }

        [HttpGet("pages", Name = $"{ControllersConstants.ORDERS}/{nameof(Get)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Obtener ordenes", Description = "Obtiene las ordenes de forma paginada")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid? cursor, bool? isNextPage, int pageSize = 5)
        {
            GetQuery<Order> query = new GetQuery<Order>(cursor,isNextPage, pageSize);
            GetQueryResult<Order> result = await sender.Send(query, cancellationToken);

            if (result.Data is null) return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}", Name = $"{ControllersConstants.ORDERS}/{nameof(GetById)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Obtener orden por id", Description = "Obtiene una orden por su id")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] bool includeFurtherData, CancellationToken cancellationToken)
        {
            GetOrderByIdQuery query = new GetOrderByIdQuery(id, includeFurtherData);
            GetOrderByIdQueryResult result = await sender.Send(query, cancellationToken);

            if (result.Order is null) return NoContent();

            return Ok(result);
        }

        [HttpDelete("{id}", Name = $"{ControllersConstants.ORDERS}/{nameof(Delete)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Eliminar orden", Description = "Elimina una orden por su id")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(id);
            DeleteOrderCommandResult result = await sender.Send(command, cancellationToken);

            if (result.StatusCode == StatusCodes.Status404NotFound) return NotFound(result);

            return NoContent();
        }

    }
}
