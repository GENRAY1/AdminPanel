using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Clients.GetList;

public class ClientDto
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Email { get; init; }
    
    public required DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; init; }
    
    public decimal Balance { get; init; }
    
    public IEnumerable<ClientTagEnum> Tags { get; init; } = [];
}