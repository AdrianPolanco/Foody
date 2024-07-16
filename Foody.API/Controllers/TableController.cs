using AutoMapper;
using Foody.API.Requests.Tables;
using Foody.Core.Application.Features;
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
        public async Task<IActionResult> Create([FromBody] CreateTableRequest request, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            CreateTableCommand command = mapper.Map<CreateTableCommand>(request);

            CreateTableCommandResult result = await sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(Create), result);
        }
    }
}
