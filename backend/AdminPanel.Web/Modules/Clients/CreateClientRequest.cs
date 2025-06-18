using AdminPanel.Domain.Clients;

namespace AdminPanel.Web.Modules.Clients;

public class CreateClientRequest
{
    public required string Name { get; init; }
    
    public required string Email { get; init; }
    
    public decimal Balance { get; init; }
    
    public List<ClientTagEnum> Tags { get; init; } = [];
}