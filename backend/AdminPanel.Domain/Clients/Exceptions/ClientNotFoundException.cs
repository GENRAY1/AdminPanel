using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.Clients.Exceptions;

public class ClientNotFoundException(Guid id) 
    : ApiException($"Client with identifier {id} not found", HttpStatusCode.NotFound);