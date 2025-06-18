using AdminPanel.Domain.Clients;
using AdminPanel.Domain.Rates;

namespace AdminPanel.Domain.Payments;

public class Payment
{
    public required Guid Id { get; init; }
    public required decimal Amount { get; init; } 
    public required DateTime CreatedAt { get; init; }
    public required Guid ClientId { get; init; }
    public required Guid RateId { get; init; }
    public Client Client { get; init; } = null!;
    public Rate Rate { get; init; } = null!;
    
    public decimal Cost => Amount * Rate.Value; 
}