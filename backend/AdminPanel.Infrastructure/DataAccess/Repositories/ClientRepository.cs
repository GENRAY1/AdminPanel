using AdminPanel.Domain.Clients;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess.Repositories;

internal class ClientRepository(ApplicationDbContext context): IClientRepository
{
    public Task<List<Client>> GetAllAsync(CancellationToken cancellationToken)
    {
        return context.Set<Client>()
            .Include(x => x.Tags)
            .ToListAsync(cancellationToken);
    }

    public async Task<Client?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<Client>()
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(Client client, CancellationToken cancellationToken)
       => context.Set<Client>().Update(client);
    
    public async Task AddAsync(Client client, CancellationToken cancellationToken)
        => await context.Set<Client>().AddAsync(client, cancellationToken);

    public void Delete(Client client) 
        => context.Set<Client>().Remove(client);
    
    public Task SaveAsync(CancellationToken cancellationToken)
        => context.SaveChangesAsync(cancellationToken);
}