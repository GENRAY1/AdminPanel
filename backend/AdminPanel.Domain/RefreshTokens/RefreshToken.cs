using AdminPanel.Domain.RefreshTokens.Exceptions;

namespace AdminPanel.Domain.RefreshTokens;

public class RefreshToken
{
    private RefreshToken() { }
    public required Guid Id { get; init; }
    
    public string Value { get; private set; } = null!;
    
    public DateTime ExpirationDate { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public Guid AccountId { get; private init; } 
    
    public void Deactivate() => IsActive = false;

    public void Activate(string value, DateTime expirationDate)
    {
        IsActive = true;
        ExpirationDate = expirationDate;
        Value = value;
    }
    
    public void Validate(DateTime utcNow, string value)  {
        
        if (IsActive == false)
            throw new RefreshTokenNotActiveException();

        if (ExpirationDate < utcNow)
            throw new RefreshTokenExpiredException();

        if (Value != value)
            throw new InvalidRefreshTokenException();
    }
    
    public static RefreshToken Create(
        Guid userId, 
        string value,
        DateTime expirationDate)
    {
        return new RefreshToken
        {
            Id = Guid.NewGuid(),
            Value = value,
            ExpirationDate = expirationDate,
            IsActive = true,
            AccountId = userId
        };
    }
    
}