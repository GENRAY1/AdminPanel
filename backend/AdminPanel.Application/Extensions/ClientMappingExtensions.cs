using AdminPanel.Application.Dtos;
using AdminPanel.Domain.Clients;

namespace AdminPanel.Application.Extensions;

public static class ClientMappingExtensions
{
    public static ClientDto ToDto(this Client client) =>
        new ClientDto()
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Balance = client.Balance,
            CreatedAt = client.CreatedAt,
            UpdatedAt = client.UpdatedAt,
            Tags = client.Tags.Select(t => t.Tag)
        };
}