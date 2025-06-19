namespace AdminPanel.Application.Dtos;

public class RateDto
{
    public required Guid Id { get; init; }
    public required decimal Value { get; init; }
    public required DateTime CreatedAt { get; init; } 
}