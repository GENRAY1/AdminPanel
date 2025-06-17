using System.Net;

namespace AdminPanel.Domain.Common;

public class ApiException(string message, HttpStatusCode statusCode)
    : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
