using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Clients.GetList;

public class GetClientsQueryHandler (IClientRepository clientRepository)
    : IQueryHandler<GetClientsQuery, List<ClientDto>>
{
    public async Task<List<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        List<Client> clients = 
            await clientRepository.GetListAsync(cancellationToken);
        
        return clients
            .Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Balance = c.Balance,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                Tags = c.Tags.Select(t => t.Tag)
            }).ToList();
    }
}