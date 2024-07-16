using AutoMapper;
using Foody.Core.Application.Features.Table.Create;
using Foody.Core.Application.Features.Tables.Create;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;

namespace Foody.Core.Application.Features.Tables.Create
{
    public class CreateTableCommandHandler(IRepository<DinnerTable> tableRepository, IMapper mapper) : ICommandHandler<CreateTableCommand, CreateTableCommandResult>
    {
        public async Task<CreateTableCommandResult> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            DinnerTable table = mapper.Map<DinnerTable>(request);

            table = await tableRepository.CreateAsync(table, cancellationToken);

            return new CreateTableCommandResult(table, nameof(TableState.Available));
        }

    }
}
