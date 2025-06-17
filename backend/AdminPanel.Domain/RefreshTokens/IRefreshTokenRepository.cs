namespace AdminPanel.Domain.RefreshTokens;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken);
    Task AddAsync(RefreshToken refreshToken);
    void Update(RefreshToken refreshToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}