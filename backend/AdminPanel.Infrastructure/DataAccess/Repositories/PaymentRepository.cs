using AdminPanel.Domain.Payments;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess.Repositories;

internal class PaymentRepository(ApplicationDbContext context) : IPaymentRepository
{
    public async Task<List<Payment>> GetListAsync(int take, CancellationToken cancellationToken)
    {
        return await context.Set<Payment>()
            .Include(x => x.Rate)
            .Include(x => x.Client)
            .OrderByDescending(x => x.CreatedAt)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
}