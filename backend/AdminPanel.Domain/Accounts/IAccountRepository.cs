namespace AdminPanel.Domain.Accounts;

public interface IAccountRepository
{
    Task<Account?> GetByEmail(string email, CancellationToken cancellationToken);
}