using AutoMapper;
using Foody.API.Requests.Tables;
using Foody.Core.Application.Features.Table.Create;
using Foody.Core.Application.Features.Tables.Update;
using Foody.Shared.Hateoas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Foody.API.Controllers
{
    [Route($"api/{ControllersConstants.TABLES}")]
    [ApiController]
   // [Authorize(Policy = "RequireWaiterRole")]
    public class TableController(ISender sender, IMapper mapper) : ControllerBase
    {
        [HttpPost(Name = $"{ControllersConstants.TABLES}/{nameof(Create)}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CommandTableRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            UpdateTableCommand command = mapper.Map<UpdateTableCommand>(request);
            command.Id = id;

            UpdateTableCommandResult result = await sender.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
