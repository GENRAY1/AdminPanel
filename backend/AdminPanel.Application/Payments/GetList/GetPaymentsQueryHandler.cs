using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Payments;

namespace AdminPanel.Application.Payments.GetList;

public class GetPaymentsQueryHandler(IPaymentRepository paymentRepository)
    : IQueryHandler<GetPaymentsQuery, List<PaymentDto>>
{
    public async Task<List<PaymentDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
        List<Payment> payments =
            await paymentRepository.GetListAsync(request.Take, cancellationToken);

        return payments.Select(x => new PaymentDto
        {
            Id = x.Id,
            ClientId = x.ClientId,
            RateId = x.RateId,
            Amount = x.Amount,
            CreatedAt = x.CreatedAt,
            Cost = x.Cost,
            ClientName = x.Client.Name,
            RateValue = x.Rate.Value,
        }).ToList();
    }
}