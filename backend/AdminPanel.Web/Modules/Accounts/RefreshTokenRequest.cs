namespace AdminPanel.Web.Modules.Accounts;

public class RefreshTokenRequest
{
    public required Guid AccountId { get; init; } 
    public required string RefreshToken { get; init; }
}