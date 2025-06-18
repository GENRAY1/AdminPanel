namespace AdminPanel.Domain.Clients;

public class ClientTag
{
    public required Guid ClientId { get; init; }
    
    public required ClientTagEnum Tag { get; init; }
}