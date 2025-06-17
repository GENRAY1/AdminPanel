using AdminPanel.Application.Abstractions.Authentication;
using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Accounts;
using AdminPanel.Domain.Accounts.Exceptions;
using AdminPanel.Domain.RefreshTokens;

namespace AdminPanel.Application.Authentication.Login;

public class LoginCommandHandler(
    IAccountRepository accountRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IJwtProvider jwtProvider, 
    IPasswordHasher passwordManager) 
    : ICommandHandler<LoginCommand, LoginDtoResponse>
{
    public async Task<LoginDtoResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Account? account 
            = await accountRepository.GetByEmail(request.Email, cancellationToken);
        
        if (account is null || !passwordManager.Verify(request.Password, account.Password))
            throw new InvalidCredentialsException();
        
        string accessToken = jwtProvider.GenerateAccessToken(account.Id);
        
        string refreshTokenValue = jwtProvider.GenerateRefreshToken();

        int lifetimeInMinutes = jwtProvider.GetRefreshTokenLifetimeInMinutes();
        
        DateTime expirationDate = DateTime.UtcNow.AddMinutes(lifetimeInMinutes);

        RefreshToken? refreshToken = 
            await refreshTokenRepository.GetByAccountIdAsync(account.Id, cancellationToken);

        if (refreshToken is not null)
        {
            refreshToken.Activate(refreshTokenValue, expirationDate);
            
            refreshTokenRepository.Update(refreshToken);
        }
        else
        {
            RefreshToken newRefreshToken = RefreshToken.Create(account.Id, refreshTokenValue, expirationDate);
            
            await refreshTokenRepository.AddAsync(newRefreshToken);
        }
        
        await refreshTokenRepository.SaveChangesAsync(cancellationToken);

        return new LoginDtoResponse(account.Id, accessToken, refreshTokenValue);
    }
}