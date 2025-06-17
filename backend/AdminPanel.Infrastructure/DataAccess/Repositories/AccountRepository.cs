using AdminPanel.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess.Repositories;

internal sealed class AccountRepository(ApplicationDbContext context) 
    : IAccountRepository
{
    public async Task<Account?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await context
            .Set<Account>()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}