using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Authentication.Login;
using AdminPanel.Application.Authentication.Logout;
using AdminPanel.Application.Authentication.Refresh;
using AdminPanel.Application.Clients.Create;
using AdminPanel.Application.Clients.Delete;
using AdminPanel.Application.Clients.GetList;
using AdminPanel.Application.Clients.Update;
using AdminPanel.Web.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Modules.Clients;

public class ClientsModule : IModule
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        var clientResource = app.MapGroup("clients");

        clientResource.MapPost("/", async (
            [FromBody] CreateClientRequest request,
            ICommandHandler<CreateClientCommand> command,
            CancellationToken cancellationToken) =>
        {
            await command.Handle(new CreateClientCommand
                {
                    Name = request.Name,
                    Email = request.Email,
                    Balance = request.Balance,
                    Tags = request.Tags
                }, cancellationToken);

            return Results.Created();
        }).RequireAuthorization();
        
        clientResource.MapGet("/", async (
            IQueryHandler<GetClientsQuery, List<ClientDto>> query,
            CancellationToken cancellationToken) =>
        {
            List<ClientDto> clients =
                await query.Handle(new GetClientsQuery(), cancellationToken);
            
            return Results.Ok(new GetClientsResponse
            {
                Clients = clients
            });
        }).RequireAuthorization();

        clientResource.MapPut("/{id}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateClientRequest request,
            ICommandHandler<UpdateClientCommand> command,
            CancellationToken cancellationToken) =>
        {
            await command.Handle(new UpdateClientCommand
            {
                Id = id,
                Name = request.Name,
                Balance = request.Balance,
                Email = request.Email,
                Tags = request.Tags
            }, cancellationToken);
            
            return Results.Ok();
        }).RequireAuthorization();
        
        clientResource.MapDelete("/{id}", async (
            [FromRoute] Guid id,
            ICommandHandler<DeleteClientCommand> command,
            CancellationToken cancellationToken) =>
        {
            await command.Handle(new DeleteClientCommand(id), cancellationToken);
            
            return Results.NoContent();
        }).RequireAuthorization();
    }
}