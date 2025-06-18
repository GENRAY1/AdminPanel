using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Clients.Create;

public class CreateClientCommandHandler(IClientRepository clientRepository)
    : ICommandHandler<CreateClientCommand>
{
    public async Task Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        Guid id = Guid.NewGuid();
        
        Client client = new Client()
        {
            Id = id,
            Name = request.Name,
            Email = request.Email,
            Balance = request.Balance,
            CreatedAt = DateTime.UtcNow,
            Tags = request.Tags.Select(tag => new ClientTag
            {
                ClientId = id,
                Tag = tag
            }).ToList()
        };
        
        await clientRepository.AddAsync(client, cancellationToken);
        await clientRepository.SaveAsync(cancellationToken);
    }
}