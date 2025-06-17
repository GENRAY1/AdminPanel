namespace AdminPanel.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateAccessToken(Guid accountId);
    string GenerateRefreshToken();
    int GetRefreshTokenLifetimeInMinutes();
    Guid? GetAccountIdByToken(string token);
}