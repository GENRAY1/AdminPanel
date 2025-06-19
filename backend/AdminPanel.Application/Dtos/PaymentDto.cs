namespace AdminPanel.Application.Dtos;

public class PaymentDto
{
    public required Guid Id { get; init; }
    public required decimal Amount { get; init; } 
    public required DateTime CreatedAt { get; init; }
    public required Guid ClientId { get; init; }
    public required string ClientName { get; init; }
    public required Guid RateId { get; init; }
    public required decimal RateValue { get; init; }
    public required decimal Cost { get; init; }
}