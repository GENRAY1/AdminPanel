using AdminPanel.Application.Clients.GetList;

namespace AdminPanel.Web.Modules.Clients;

public class GetClientsResponse
{
    public List<ClientDto> Clients { get; init; } = [];
}