using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.RefreshTokens.Exceptions;

public class RefreshTokenNotActiveException() 
    : ApiException("Refresh token is not active", HttpStatusCode.Unauthorized);