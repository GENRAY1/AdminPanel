using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Clients.Create;
using AdminPanel.Application.Rates.Create;
using AdminPanel.Application.Rates.GetCurrent;
using AdminPanel.Web.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Modules.Rate;

public class RateModule : IModule
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        var rateResource = app.MapGroup("rate");

        rateResource.MapPost("/", async (
            [FromBody] CreateRateRequest request,
            ICommandHandler<CreateRateCommand> command,
            CancellationToken cancellationToken) =>
        {
            await command.Handle(new CreateRateCommand(request.Value), cancellationToken);

            return Results.Created();
        }).RequireAuthorization();
        
        rateResource.MapGet("/", async (
            IQueryHandler<GetCurrentRateQuery, RateDto?> query,
            CancellationToken cancellationToken) =>
        {
            RateDto? rate 
                = await query.Handle(new GetCurrentRateQuery(), cancellationToken);

            return Results.Ok(rate);
        }).RequireAuthorization();
    }
}