using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Clients.Update;

public class UpdateClientCommand : ICommand
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Email { get; init; }
    
    public decimal Balance { get; init; }
    
    public List<ClientTagEnum> Tags { get; init; } = [];
}