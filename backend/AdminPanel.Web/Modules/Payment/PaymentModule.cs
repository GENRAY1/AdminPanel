using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Payments.GetList;
using AdminPanel.Web.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Web.Modules.Payment;

public class PaymentModule : IModule
{
    public void RegisterEndpoints(IEndpointRouteBuilder app)
    {
        var paymentResource = app.MapGroup("payments");

        paymentResource.MapGet("/", async (
            IQueryHandler<GetPaymentsQuery, List<PaymentDto>> query,
            CancellationToken cancellationToken,
            [FromQuery] int take = 100) =>
        {
            List<PaymentDto> payments =
                await query.Handle(new GetPaymentsQuery(take), cancellationToken);

            return Results.Ok(new GetPaymentsResponse
            {
                Payments = payments
            });
        }).RequireAuthorization();
    }
} 