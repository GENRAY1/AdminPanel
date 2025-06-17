using AdminPanel.Application.Abstractions.Authentication;
using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Accounts;
using AdminPanel.Domain.RefreshTokens;

namespace AdminPanel.Application.Authentication.Logout;

public class LogoutCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
    IAccountContext accountContext) 
    : ICommandHandler<LogoutCommand>
{
    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        Guid accountId = accountContext.AccountId;
        
        RefreshToken? refreshToken = 
            await refreshTokenRepository.GetByAccountIdAsync(accountId, cancellationToken);

        if (refreshToken is not null)
        {
            refreshToken.Deactivate();
            await refreshTokenRepository.SaveChangesAsync(cancellationToken);
        }
    }
}