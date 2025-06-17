namespace AdminPanel.Application.Authentication.Login;

public record LoginDtoResponse (Guid AccountId, string AccessToken, string RefreshToken);