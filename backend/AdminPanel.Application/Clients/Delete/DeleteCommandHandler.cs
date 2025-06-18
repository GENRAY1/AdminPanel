using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Clients;
using AdminPanel.Domain.Clients.Exceptions;

namespace AdminPanel.Application.Clients.Delete;

public class DeleteCommandHandler (IClientRepository clientRepository)
    : ICommandHandler<DeleteClientCommand>
{
    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        Client? client = 
            await clientRepository.GetAsync(request.Id, cancellationToken);
        
        if (client is null)
            throw new ClientNotFoundException(request.Id);
        
        clientRepository.Delete(client);
        await clientRepository.SaveAsync(cancellationToken);
    }
}