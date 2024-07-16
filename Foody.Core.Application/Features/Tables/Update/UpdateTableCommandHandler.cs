
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Foody.Core.Application.Features.Tables.Update
{
    public class UpdateTableCommandHandler(IRepository<DinnerTable> tableRepository) : ICommandHandler<UpdateTableCommand, UpdateTableCommandResult>
    {
        public async Task<UpdateTableCommandResult> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            DinnerTable? table = await tableRepository.GetByIdAsync(request.Id, cancellationToken);

            if (table is null) return new UpdateTableCommandResult(table, StatusCodes.Status404NotFound, false);

            if(string.IsNullOrWhiteSpace(request.Description) || request.Seats < 1) new UpdateTableCommandResult(table, StatusCodes.Status400BadRequest, false);

            table.Description = request.Description;
            table.Capacity = request.Seats;

            table = await tableRepository.UpdateAsync(table, cancellationToken);

            return new UpdateTableCommandResult(table, StatusCodes.Status200OK, true);
        }
    }
}
