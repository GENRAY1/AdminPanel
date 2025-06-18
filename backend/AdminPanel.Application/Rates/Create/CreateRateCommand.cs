using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Rates.Create;

public record CreateRateCommand(decimal Value) : ICommand;
