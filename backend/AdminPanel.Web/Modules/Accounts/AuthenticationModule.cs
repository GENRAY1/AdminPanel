using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Authentication.Login;
using AdminPanel.Application.Authentication.Logout;
using AdminPanel.Application.Authentication.Refresh;
using AdminPanel.Web.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Modules.Accounts;

public class AuthenticationModule : IModule
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        var authResource = app.MapGroup("auth");

        authResource.MapPost("/login", async (
            [FromBody] LoginRequest request,
            ICommandHandler<LoginCommand, LoginDtoResponse> command,
            CancellationToken cancellationToken) =>
        {
            LoginDtoResponse response = await command.Handle(
                new LoginCommand(request.Email, request.Password),
                cancellationToken);

            return Results.Ok(response);
        });

        authResource.MapPost("/logout", async (
            ICommandHandler<LogoutCommand> command,
            CancellationToken cancellationToken) =>
        {
            await command.Handle(new LogoutCommand(), cancellationToken);
            
            return Results.Ok();
        }).RequireAuthorization();

        authResource.MapPost("/refresh", async (
            [FromBody] RefreshTokenRequest request,
            ICommandHandler<RefreshTokenCommand, RefreshTokenDtoResponse> command,
            CancellationToken cancellationToken) =>
        {
            RefreshTokenDtoResponse response =
                await command.Handle(new RefreshTokenCommand(request.AccountId, request.RefreshToken), cancellationToken);
            
            return Results.Ok(response);
        });
    }
}