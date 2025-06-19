using AdminPanel.Application.Dtos;
using AdminPanel.Application.Payments.GetList;

namespace AdminPanel.Web.Modules.Payment;

public class GetPaymentsResponse
{
    public List<PaymentDto> Payments { get; init; } = [];
}