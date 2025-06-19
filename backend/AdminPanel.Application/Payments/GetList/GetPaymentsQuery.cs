using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Dtos;

namespace AdminPanel.Application.Payments.GetList;

public record GetPaymentsQuery(int Take) : IQuery<List<PaymentDto>>;