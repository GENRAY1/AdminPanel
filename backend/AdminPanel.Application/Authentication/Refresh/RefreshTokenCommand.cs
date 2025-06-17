using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Authentication.Refresh;

public record RefreshTokenCommand(Guid AccountId, string RefreshToken) 
    : ICommand<RefreshTokenDtoResponse>;