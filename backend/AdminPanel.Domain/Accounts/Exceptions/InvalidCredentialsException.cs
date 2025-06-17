using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.Accounts.Exceptions;

public class InvalidCredentialsException()
    : ApiException("Invalid credentials", HttpStatusCode.Unauthorized);