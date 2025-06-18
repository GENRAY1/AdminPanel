namespace AdminPanel.Domain.Rates;

public interface IRateRepository
{
    Task<Rate?> GetCurrentAsync(CancellationToken cancellationToken);
    
    Task AddAsync(Rate client, CancellationToken cancellationToken);
    
    Task SaveAsync(CancellationToken cancellationToken);
}