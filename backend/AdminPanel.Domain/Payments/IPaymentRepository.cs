namespace AdminPanel.Domain.Payments;

public interface IPaymentRepository
{
    Task<List<Payment>> GetListAsync(int take, CancellationToken cancellationToken);
}