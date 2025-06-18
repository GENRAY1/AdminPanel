namespace AdminPanel.Domain.Clients;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Client?> GetAsync(Guid id, CancellationToken cancellationToken);
    
    void Update(Client client, CancellationToken cancellationToken);
    
    void Delete(Client client);
    
    Task AddAsync(Client client, CancellationToken cancellationToken);
    
    Task SaveAsync(CancellationToken cancellationToken);
}