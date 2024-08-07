﻿using Foody.Core.Application.Interfaces.MediatR.CQRS.Commands;
using Foody.Core.Domain.Entities;
using Foody.Core.Domain.Enums;


namespace Foody.Core.Application.Features.Table.Create
{
    public record CreateTableCommand(string Description, int Seats, TableState State = TableState.Available) : ICommand<CreateTableCommandResult>;
    public record CreateTableCommandResult(DinnerTable Table, string StateName);
}
