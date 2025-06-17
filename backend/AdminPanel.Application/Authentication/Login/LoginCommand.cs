using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Authentication.Login;

public record LoginCommand(string Email, string Password) : ICommand<LoginDtoResponse>;