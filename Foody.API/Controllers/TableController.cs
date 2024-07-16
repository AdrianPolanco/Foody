using AutoMapper;
using Foody.API.Requests.Tables;
using Foody.Core.Application.Features.Common;
using Foody.Core.Application.Features.Table.Create;
using Foody.Core.Application.Features.Tables.GetById;
using Foody.Core.Application.Features.Tables.GetPendingOrders;
using Foody.Core.Application.Features.Tables.Update;
using Foody.Core.Application.Features.Tables.UpdateStatus;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Foody.API.Controllers
{
    [Route($"api/{ControllersConstants.TABLES}")]
    [ApiController]
    public class TableController(ISender sender, IMapper mapper) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.TABLES}/{nameof(Create)}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       // [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> Create([FromBody] CommandTableRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateTableCommand command = mapper.Map<CreateTableCommand>(request);

            CreateTableCommandResult result = await sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(Create), result);
        }

        [HttpPut("{id}", Name = $"{ControllersConstants.TABLES}/{nameof(Update)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CommandTableRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            UpdateTableCommand command = mapper.Map<UpdateTableCommand>(request);
            command.Id = id;

            UpdateTableCommandResult result = await sender.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet("pages", Name = $"{ControllersConstants.TABLES}/{nameof(Get)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener mesas", Description = "Obtiene las mesas con paginación")]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken cancellationToken,Guid? cursor, bool? isNextPage, int pageSize = 5)
        {
            GetQuery<DinnerTable> query = new GetQuery<DinnerTable>(cursor, isNextPage, pageSize);
            GetQueryResult<DinnerTable> tables = await sender.Send(query, cancellationToken);

            if(!tables.Data.Any()) return NoContent();

            return Ok(tables);
        }

        [HttpGet("{id}", Name = $"{ControllersConstants.TABLES}/{nameof(GetById)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener mesa", Description = "Obtiene una mesa por su id")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetTableByIdQuery(id);

            DinnerTable? table = await sender.Send(query, cancellationToken);

            if(table is null) return NoContent();

            return Ok(table);
        }

        [HttpPut("{id}/state", Name = $"{ControllersConstants.TABLES}/{nameof(ChangeState)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "RequireWaiterRole")]
        public async Task<IActionResult> ChangeState([FromRoute] Guid id, 
            [FromQuery][SwaggerParameter(Description = "1: Disponible<br>2: En atención<br>3: Atendida")] TableState status, CancellationToken cancellationToken)
        {
          UpdateTableStatusCommand command = new UpdateTableStatusCommand(id, status);

            DinnerTable? result = await sender.Send(command, cancellationToken);

            if(result is null) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/orders", Name = $"{ControllersConstants.TABLES}/{nameof(GetOrders)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(Summary = "Obtener pedidos en proceso de una mesa", Description = "Obtiene los pedidos pendientes de una mesa por su id")]
        //[Authorize(Policy = "RequireWaiterRole")]
        public async Task<IActionResult> GetOrders([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPendingOrdersQuery(id);

            GetPendingOrdersQueryResult result = await sender.Send(query, cancellationToken);

            if(result.TotalPendingOrders < 1) return NoContent();

            return Ok(result);
        }
    }
}
