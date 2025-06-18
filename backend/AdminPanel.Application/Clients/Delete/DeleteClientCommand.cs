using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Clients.Delete;

public record DeleteClientCommand(Guid Id) : ICommand;