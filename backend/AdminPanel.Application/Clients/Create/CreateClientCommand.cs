using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Dtos;
using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Clients.Create;

public class CreateClientCommand : ICommand<ClientDto>
{
    public required string Name { get; init; }
    
    public required string Email { get; init; }
    
    public decimal Balance { get; init; }
    
    public List<ClientTagEnum> Tags { get; init; } = [];
}