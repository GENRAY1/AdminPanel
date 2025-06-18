namespace AdminPanel.Domain.Clients;

public class Client
{
    
    private decimal _balance;
    public required Guid Id { get; init; }
    
    public required string Name { get; set; }
    
    public required string Email { get; set; }
    
    public required DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }

    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative");
            
            _balance = value;
        }
    }

    public List<ClientTag> Tags { get; set; } = [];
}