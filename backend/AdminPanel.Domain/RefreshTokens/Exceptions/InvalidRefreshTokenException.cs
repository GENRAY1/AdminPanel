using System.Net;
using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.RefreshTokens.Exceptions;

public class InvalidRefreshTokenException()
    : ApiException("Invalid refresh token", HttpStatusCode.BadRequest);