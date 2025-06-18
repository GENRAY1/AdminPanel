using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Clients;
using AdminPanel.Domain.Clients.Exceptions;

namespace AdminPanel.Application.Clients.Update;

public class UpdateClientCommandHandler (IClientRepository clientRepository)
    : ICommandHandler<UpdateClientCommand>
{
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        Client? client = 
            await clientRepository.GetAsync(request.Id, cancellationToken);
        
        if (client is null)
            throw new ClientNotFoundException(request.Id);
        
        List<ClientTag> clientTags = request.Tags.Select(tag => new ClientTag
        {
            ClientId = client.Id,
            Tag = tag
        }).ToList();
        
        client.Name = request.Name;
        client.Email = request.Email;
        client.Balance = request.Balance;
        client.UpdatedAt = DateTime.UtcNow;
        client.Tags = clientTags;
        
        await clientRepository.SaveAsync(cancellationToken);
    }
}