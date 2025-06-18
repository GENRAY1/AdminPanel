namespace AdminPanel.Domain.Rates;

public class Rate
{
    public required Guid Id { get; init; }
    public required decimal Value { get; init; }
    public required DateTime CreatedAt { get; init; }
}