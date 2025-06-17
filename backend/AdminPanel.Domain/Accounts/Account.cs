namespace AdminPanel.Domain.Accounts;

public class Account
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required DateTime CreatedAt { get; init; }
}