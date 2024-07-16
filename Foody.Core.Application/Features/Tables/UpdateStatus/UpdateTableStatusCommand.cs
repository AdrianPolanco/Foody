

using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Application.Features.Tables.UpdateStatus
{
    public record UpdateTableStatusCommand(Guid TableId, TableState State) : ICommand<DinnerTable?>;
}
