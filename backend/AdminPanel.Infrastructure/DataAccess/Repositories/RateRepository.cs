using AdminPanel.Domain.Rates;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess.Repositories;

internal class RateRepository(ApplicationDbContext context) : IRateRepository
{
    public async Task<Rate?> GetCurrentAsync(CancellationToken cancellationToken)
    {
        return await context.Set<Rate>()
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Rate client, CancellationToken cancellationToken) 
        => await context.Set<Rate>().AddAsync(client, cancellationToken);

    public async Task SaveAsync(CancellationToken cancellationToken)
        => await context.SaveChangesAsync(cancellationToken);
}