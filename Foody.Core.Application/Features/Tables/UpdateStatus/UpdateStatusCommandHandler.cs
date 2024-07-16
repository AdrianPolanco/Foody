
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using MediatR;

namespace Foody.Core.Application.Features.Tables.UpdateStatus
{
    public class UpdateStatusCommandHandler(IEntityService<DinnerTable> tableService) : IRequestHandler<UpdateTableStatusCommand, DinnerTable?>
    {
        public async Task<DinnerTable?> Handle(UpdateTableStatusCommand request, CancellationToken cancellationToken)
        {
            DinnerTable? table = await tableService.GetByIdAsync(request.TableId, cancellationToken);

            if(table is null) return table;

            if(request.State == table.State) return table; // No actualizar si el estado es el mismo

            table.State = request.State;

            return await tableService.UpdateAsync(table, cancellationToken);
        }
    }
}
