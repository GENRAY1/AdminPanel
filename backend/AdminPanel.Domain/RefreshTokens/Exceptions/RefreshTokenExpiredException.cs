using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.RefreshTokens.Exceptions;

public class RefreshTokenExpiredException()
    : ApiException("Refresh token is expired", HttpStatusCode.Unauthorized);