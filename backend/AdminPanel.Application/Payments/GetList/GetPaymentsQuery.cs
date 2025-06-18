using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Payments.GetList;

public record GetPaymentsQuery(int Take) : IQuery<List<PaymentDto>>;