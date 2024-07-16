using AutoMapper;
using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;
using Foody.Core.Domain.Interfaces;

namespace Foody.Core.Application.Features.CreateTable
{
    public class CreateTableCommandHandler(IRepository<Table> tableRepository, IMapper mapper) : ICommandHandler<CreateTableCommand, CreateTableCommandResult>
    {
        public async Task<CreateTableCommandResult> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            Table table = mapper.Map<Table>(request);

            table = await tableRepository.CreateAsync(table, cancellationToken);

            return new CreateTableCommandResult(table, nameof(TableState.Available));
        }
    }
}
