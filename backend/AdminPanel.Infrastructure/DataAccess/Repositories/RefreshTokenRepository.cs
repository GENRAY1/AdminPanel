using AdminPanel.Domain.RefreshTokens;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess.Repositories;

internal sealed class RefreshTokenRepository(ApplicationDbContext context)
    : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
    {
        return await context
            .Set<RefreshToken>()
            .FirstOrDefaultAsync(x => x.AccountId == accountId, cancellationToken);
    }

    public async Task AddAsync(RefreshToken refreshToken) 
        => await context.AddAsync(refreshToken);
    
    public void Update(RefreshToken refreshToken) 
        => context.Update(refreshToken);
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken) 
        => await context.SaveChangesAsync(cancellationToken);
}