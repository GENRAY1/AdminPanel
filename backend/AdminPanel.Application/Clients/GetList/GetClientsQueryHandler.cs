using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Dtos;
using AdminPanel.Application.Extensions;
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
            .Select(c => c.ToDto())
            .ToList();
    }
}