using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Features.Tables.Update
{
    public record UpdateTableCommand(string Description, int Seats) : ICommand<UpdateTableCommandResult>
    {
           public Guid Id { get; set; }
    }
    public record UpdateTableCommandResult(DinnerTable? Table, int StatusCode, bool Success);
    
}
