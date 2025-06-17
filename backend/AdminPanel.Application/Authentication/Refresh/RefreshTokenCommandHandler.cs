using AdminPanel.Application.Abstractions.Authentication;
using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Accounts;
using AdminPanel.Domain.RefreshTokens;

namespace AdminPanel.Application.Authentication.Refresh;

public class RefreshTokenCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
    IAccountContext accountContext,
    IJwtProvider jwtProvider) 
    : ICommandHandler<RefreshTokenCommand, RefreshTokenDtoResponse>
{
    public async Task<RefreshTokenDtoResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        Guid accountId = request.AccountId;
        
        RefreshToken? refreshToken = 
            await refreshTokenRepository.GetByAccountIdAsync(accountId, cancellationToken);

        if (refreshToken is null)
            throw new InvalidOperationException("Cannot refresh access token");

        refreshToken.Validate(DateTime.UtcNow, request.RefreshToken);
        
        string accessTokenValue = jwtProvider.GenerateAccessToken(refreshToken.AccountId);

        return new RefreshTokenDtoResponse(accessTokenValue);
    }
}