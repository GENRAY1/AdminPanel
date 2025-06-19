using AdminPanel.Application.Clients.GetList;
using AdminPanel.Application.Dtos;

namespace AdminPanel.Web.Modules.Clients;

public class GetClientsResponse
{
    public List<ClientDto> Clients { get; init; } = [];
}